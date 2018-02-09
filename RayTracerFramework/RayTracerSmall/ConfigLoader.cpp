#include "ConfigLoader.h"

ConfigLoader::ConfigLoader(const std::string &fName)
{
	this->fName = fName;
	ExtractKeys();
}
ConfigLoader::~ConfigLoader()
{

}

bool ConfigLoader::KeyExists(const std::string &key) const
{
	return contents.find(key) != contents.end();
}


void ConfigLoader::RemoveComment(string &line) const
{
	if (line.find(';') != line.npos)
	{
		line.erase(line.find(';'));
	}
}

bool ConfigLoader::OnlyWhitespace(const string &line) const
{
	return (line.find_first_not_of(' ') == line.npos);
}

bool ConfigLoader::ValidLine(const string &line) const
{
		string temp = line;
		temp.erase(0, temp.find_first_not_of("\t "));

		if (temp[0] == '=')
		{
			return false;
		}

		for (size_t i = temp.find('=') + 1; i < temp.length(); i++)
		{
			if (temp[i] != ' ')
			{
				return true;
			}
		}

		return false;
}

void ConfigLoader::ExtractKey(std::string &key, size_t const &sepPos, const std::string &line) const
{
	key = line.substr(0, sepPos);

	if (key.find('\t') != line.npos || key.find(' ') != line.npos)
	{
		key.erase(key.find_first_of("\t "));
	}
}

void ConfigLoader::ExtractValue(std::string &value, size_t const &sepPos, const std::string &line) const
{
	value = line.substr(sepPos + 1);
	value.erase(0, value.find_first_not_of("\t "));
	value.erase(value.find_last_not_of("\t ") + 1);
}

void ConfigLoader::ExtractContents(const std::string &line)
{
	std::string temp = line;
	// Erase leading whitespace from the line.
	temp.erase(0, temp.find_first_not_of("\t "));
	size_t sepPos = temp.find('=');

	std::string key, value;
	ExtractKey(key, sepPos, temp);
	ExtractValue(value, sepPos, temp);

	if (!KeyExists(key))
		contents.insert(std::pair<std::string, std::string>(key, value));
	else
		ExitWithError("CFG: Can only have unique key names!\n");
}

// lineNo = the current line number in the file.
// line = the current line, with comments removed.
void ConfigLoader::ParseLine(const std::string &line, size_t const lineNo)
{
	if (line.find('=') == line.npos)
		ExitWithError("CFG: Couldn't find separator on line: " + Convert::T_To_String(lineNo) + "\n");

	if (!ValidLine(line))
		ExitWithError("CFG: Bad format for line: " + Convert::T_To_String(lineNo) + "\n");

	ExtractContents(line);
}

void ConfigLoader::ExtractKeys()
{
	std::ifstream file;
	file.open(fName.c_str());
	if (!file)
		ExitWithError("CFG: File " + fName + " couldn't be found!\n");

	std::string line;
	size_t lineNo = 0;
	while (std::getline(file, line))
	{
		lineNo++;
		std::string temp = line;

		if (temp.empty())
			continue;

		RemoveComment(temp);
		if (OnlyWhitespace(temp))
			continue;

		ParseLine(temp, lineNo);
	}

	file.close();
}

void ConfigLoader::ExitWithError(const std::string &error)
{
	std::cout << error;
	std::cin.ignore();
	std::cin.get();

	exit(EXIT_FAILURE);
}
