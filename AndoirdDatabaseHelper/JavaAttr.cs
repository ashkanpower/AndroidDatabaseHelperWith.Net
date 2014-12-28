using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndoirdDatabaseHelper
{
    public class JavaAttr
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public SqliteType SqlType { set; get; }

        public bool IsEffective { set; get; }
        public bool IsPrimaryKey { set; get; }

        public JavaClass Class { set; get; }

        public string GetFromCursorType {
            get
            {
                switch (Type)
                {
                    case "int":
                        return "Int";
                    case "String":
                        return "String"; 
                    case "float":
                        return "Float";
                    case "double":
                        return "Double"; 
                    case "long":
                        return "Long";
                    case "boolean":
                        return "Int";

                }

                return "String";
            }
        }

        public JavaAttr(JavaClass theClass, string name, string type)
        {

            this.Class = theClass;
            this.Name = name;
            this.Type = type;

            switch (this.Type)
            {

                case "int":
                    this.SqlType = SqliteType.INTEGER;
                    break;
                case "String":
                    this.SqlType = SqliteType.TEXT;
                    break;
                case "boolean":
                    this.SqlType = SqliteType.INTEGER;
                    break;
                case "double":
                    this.SqlType = SqliteType.REAL;
                    break;
                case "long":
                    this.SqlType = SqliteType.REAL;
                    break;
                case "float":
                    this.SqlType = SqliteType.REAL;
                    break;
            }
        }

        public string AttrTableName
        {

            get
            {
                return Class.Name.ToUpper() +  "_" + Name.ToUpper();
            }
        }

        public override string ToString()
        {
            return this.Name +  " - " + this.Type + " - " + this.SqlType  ;
        }
    }
}
