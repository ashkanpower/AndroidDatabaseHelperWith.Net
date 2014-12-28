using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndoirdDatabaseHelper
{
    public static class QueryHelper
    {


        public static string GenerateCreateTable(JavaClass theClass)
        {

            string query = "\nprivate static final String " + theClass.TableName + " = \"" + theClass.Name.ToLower() + "\";\n\n";

            query += "//" + theClass.TableName + "\n";
            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective == true))
            {
                query += "private static final String " + attr.AttrTableName + " = \"" + attr.AttrTableName.ToLower() + "\";\n";
            }

            query += "\n\n\n";

            query += "String CREATE_" + theClass.TableName + " = \n";

                
            query += "  \"CREATE TABLE \" + " + theClass.TableName + " + \"(\" \n" ;

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective == true))
            {
                if (attr.IsPrimaryKey)
                {
                    query += "      + " + attr.AttrTableName + " + \" " + attr.SqlType + " PRIMARY KEY, \" \n";
                }
                else
                {
                    query += "      + " + attr.AttrTableName + " + \" " + attr.SqlType + ", \" \n";
                }
            }

            query = query.Remove(query.Length - 5, 5);

            query += "\"\n      + \")\";";
            query += "\ndb.execSQL(CREATE_" + theClass.TableName + ");";

            return query;
        }

        public static string GenerateSelectAll(JavaClass theClass)
        {

            string ObjectName = theClass.Name.ToLower();

            string query = "public ArrayList<"+theClass.Name+"> getAll"+theClass.Name+"s() { \n";

            query += "  SQLiteDatabase db = getReadableDatabase();\n";
            query += "  final Cursor cursor = db.rawQuery(\"SELECT * FROM \" + " + theClass.TableName + ", null); \n";
            query += "  ArrayList<" + theClass.Name + "> " + theClass.Name.ToLower() + "s = new ArrayList<" + theClass.Name + ">();\n\n";

            query += "  if (cursor != null) {\n     if (cursor.moveToFirst()) {\n           do {\n";

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective == true))
            {

                query += "                  " + attr.Type + " " + attr.Name.ToLower() + " = cursor.get"+ attr.GetFromCursorType + "(cursor.getColumnIndex(" + attr.AttrTableName + "))" + (attr.Type == "boolean" ? " != 0" : "") + "; \n";
                
            }

            query += "\n                  " + theClass.Name + " " + ObjectName + " = new " + theClass.Name + "(); \n";

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective == true))
            {
                query += "                  " + ObjectName + ".set" + attr.Name.ToUpperFirst() + "(" + attr.Name.ToLower() + ");\n";
            }

            

            query += "\n                  " + theClass.Name.ToLower() + "s.add(" + ObjectName + ");\n";

            query += "              } while (cursor.moveToNext()); \n           }\n     }\n\n";
            query += "  return " + theClass.Name.ToLower() + "s;\n }";


            return query;
        }

        public static string GenerateInsertQuery(JavaClass theClass)
        {

            string ObjectName = theClass.Name.ToLower();

            string query = "public void insert" + theClass.Name.ToLower().ToUpperFirst() + "("+theClass.Name+" "+ObjectName+") { \n";

            query += "  ContentValues values = new ContentValues();\n";

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective && !a.IsPrimaryKey))
            {
                query += "   values.put(" + attr.AttrTableName + ", " + ObjectName + ".get" + attr.Name.ToUpperFirst() + "());\n";
            }

            query += "  this.getWritableDatabase().insert(" + theClass.TableName + ", null, values);";

            query += "\n}";

            return query;
        }


        public static string GenerateUpdateQuery(JavaClass theClass)
        {

            string ObjectName = theClass.Name.ToLower();

            string query = "public void update" + theClass.Name.ToLower().ToUpperFirst() + "(" + theClass.Name + " " + ObjectName + ") { \n";

            query += "  SQLiteDatabase db = getWritableDatabase();\n";

            query += "  String query = \"UPDATE \" + "+theClass.TableName+" + \" SET \" \n";

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective && !a.IsPrimaryKey))
            {
                query += "      + " + attr.AttrTableName + " + \" = \\\"\" + " + ObjectName + ".get" + attr.Name.ToUpperFirst() + "() + \"\\\" , \"\n";
            }

            query = query.Remove(query.Length - 10, 10);

            JavaAttr pk = theClass.Attributes.First(a => a.IsPrimaryKey);

            query += "\n      + \"\\\" WHERE \" + " + pk.AttrTableName + " + \" = \\\"\" + " + ObjectName + ".get" + pk.Name.ToUpperFirst() + "() + \"\\\";\";";

            query += "\n  db.execSQL(query);";

            query += "\n}";

            return query;

            //SQLiteDatabase db = getWritableDatabase();
            //db.execSQL("UPDATE " + TABLE_FALIAT + " SET " + FALIAT_KEY_SENT + " =\"1\" Where " + FALIAT_KEY_ID + " In " + idIn + ";");

        }


        public static string GenerateDeleteQuery(JavaClass theClass)
        {

            string ObjectName = theClass.Name.ToLower();

            string query = "public void delete" + theClass.Name.ToLower().ToUpperFirst() + "(" + theClass.Name + " " + ObjectName + ") { \n";

            query += "  SQLiteDatabase db = getWritableDatabase();\n";

            JavaAttr pk = theClass.Attributes.First(a => a.IsPrimaryKey);

           // query += "  String query = \"DELETE FROM \" + " + theClass.TableName + " + \" WHERE \" + " + pk.AttrTableName + " + \" = \" + " + ObjectName + ".get" + pk.Name.ToUpperFirst() + "();  \n";

           // query += "  db.rawQuery(query, null);";

            query += "  db.delete(" + theClass.TableName + ", " + pk.AttrTableName + " + \" = \" + " + ObjectName + ".get" + pk.Name.ToUpperFirst() + "(), null);";
            

            query += "\n}";

            return query;

            //SQLiteDatabase db = getWritableDatabase();
            //db.execSQL("UPDATE " + TABLE_FALIAT + " SET " + FALIAT_KEY_SENT + " =\"1\" Where " + FALIAT_KEY_ID + " In " + idIn + ";");

        }

        public static string GenerateGetView(JavaClass theClass)
        {

            string query = "public View getView(Context context, View oldView) { \n";

            query += "  if (oldView == null || !(oldView.getTag() instanceof " + theClass.Name + ")) { \n";
            query += "      LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);\n";

            query += "          oldView = inflater.inflate(R.layout.item_" + theClass.Name.ToLower() + ", null);\n";
            query += "          Holder holder = new Holder();\n";
            query += "          oldView.setTag(holder);\n getItem(holder, oldView);\n return oldView;\n";
            query += "      } else {";

            query += "          Holder holder = (Holder) oldView.getTag();\ngetItem(holder, oldView);\nreturn oldView;";

            query += "      }\n}";

            return query;

        }


        public static string GenerateGetItem(JavaClass theClass)
        {

            string query = "private void getItem(Holder holder, View view) {\n";

            query += " holder."+ theClass.Name.ToLower() +" = this;";


            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective))
            {
                query += "  if (holder."+ attr.Name.ToLower() +" == null)\n";
                query += "      holder." + attr.Name.ToLower() + " = (TextView) view.findViewById(R.id." + attr.Name.ToLower() + ");\n\n";
            }

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective))
            {
                query += "  holder." + attr.Name.ToLower() + ".setText(this.get"+attr.Name.ToUpperFirst()+"());\n";
            }

            query += "}";

            return query;

        }

        public static string GenerateHolderClass(JavaClass theClass)
        {

            string query = "public class Holder { \n";

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective))
            {
                query += "  TextView "+ attr.Name.ToLower() +";\n";
            }

            query += "\n    " + theClass.Name + " " + theClass.Name.ToLower() + "; \n";

            query += "}";

            return query;
        }

        public static string GenerateSampleView(JavaClass theClass)
        {
            string query = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n\n"+
                "<LinearLayout xmlns:android=\"http://schemas.android.com/apk/res/android\"\n"+
                    "   android:orientation=\"vertical\" android:layout_width=\"match_parent\"\n"+
                    "   android:layout_height=\"match_parent\">\n\n";

            foreach (JavaAttr attr in theClass.Attributes.Where(a => a.IsEffective))
            {
                query += "  <TextView \n        android:id=\"@+id/" + attr.Name.ToLower() + "\"\n" +
                    "       android:layout_width=\"fill_parent\"\n" +
                    "       android:layout_height=\"wrap_content\" />\n\n ";
            }

            query += "</LinearLayout>";

            return query;

            
        }

        static string ToUpperFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        
    }
}
