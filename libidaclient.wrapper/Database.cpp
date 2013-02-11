#include <atlstr.h>
#include "Database.h"

using System::String;

namespace Ida {
	namespace Client {
		Database::Database(::Database *database) : m_database(database)
		{
		}

		Database::~Database(void) {
			if (m_database != nullptr) {
				delete m_database;
			}
		}

		Database^ Database::Open(String^ path) {
			::Database *database = ::Database::Open(CString(path));
			if (database == nullptr) {
				throw gcnew System::ArgumentException(String::Format("Can't open database for {0}", path));
			}
			return gcnew Database(database);
		}

		Functions^ Database::Functions::get() {
			Ida::Client::Functions^ functions = gcnew Ida::Client::Functions(m_database);			
			return functions;
		}

		Enumerations^ Database::Enumerations::get() {
			Ida::Client::Enumerations^ enumerations = gcnew Ida::Client::Enumerations(m_database);			
			return enumerations;
		}
	}
}
