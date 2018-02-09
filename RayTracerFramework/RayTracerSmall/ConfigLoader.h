#pragma once
#include <iostream>
#include <string>
#include <sstream>
#include <map>
#include <fstream>

using namespace::std;

class ConfigLoader
{
public:
	ConfigLoader(const string &fName);
	~ConfigLoader();

	bool KeyExists(const string &key) const;

	template <typename ValueType>
	ValueType GetValueOfKey(const string &key, ValueType const &defaultValue = ValueType()) const
	{
		if (!KeyExists(key))
			return defaultValue;

		return Convert::String_To_T<ValueType>(contents.find(key)->second);
	}

private:
	void RemoveComment(string &line) const;
	bool OnlyWhitespace(const string &line) const;
	bool ValidLine(const string &line) const;
	void ExtractKey(string &key, size_t const &sepPos, const string &line) const;
	void ExtractValue(string &value, size_t const &sepPos, const string &line) const;
	void ExtractContents(const string &line);
	void ParseLine(const string &line, size_t const lineNo);
	void ExtractKeys();
	void ExitWithError(const std::string &error);
private:
	map<string, string> contents;
	string fName;
};

class Convert
{
public:
	// Convert T, which should be a primitive, to a std::string.
	template <typename T>
	static string T_To_String(T const &val)
	{
		std::ostringstream ostr;
		ostr << val;

		return ostr.str();
	}

	// Convert a std::string to T.	
	template <typename T>
	static T String_To_T(string const &val)
	{
		std::istringstream istr(val);
		T returnVal;
		if (!(istr >> returnVal))
			ExitWithError("CFG: Not a valid " + (string)typeid(T).name() + " received!\n");

		return returnVal;
	}

	template <>
	static string String_To_T(string const &val)
	{
		return val;
	}

	void static ExitWithError(const std::string &error)
	{
		std::cout << error;
		std::cin.ignore();
		std::cin.get();

		exit(EXIT_FAILURE);
	}
};

