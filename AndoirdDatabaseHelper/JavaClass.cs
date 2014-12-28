using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AndoirdDatabaseHelper
{
    public class JavaClass
    {

        public string Name { set; get; }
        public string TableName
        {
            get
            {
                return "TABLE_" + this.Name.ToUpper();
            }
        }
        List<JavaAttr> attributes;
        public string Code { set; get; }


        public JavaClass(string code)
        {
            this.Code = code;

            this.attributes = new List<JavaAttr>();

            ExtractName();
            ExtractAttributes();
        }

        private void ExtractName()
        {
            string pattern = @"class (\w+)";


            Regex rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(this.Code);

            if (matches.Count == 0)
                throw new FormatException();

            Match match = matches[0];

            GroupCollection groups = match.Groups;

            this.Name = groups[1].Value;
        }

        private void ExtractAttributes()
        {

            string pattern = @"(int|String|boolean|long|double|float) (\w+);";


            Regex rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection matches = rx.Matches(this.Code);

            if (matches.Count == 0)
                throw new FormatException();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                string type = groups[1].Value;
                string name = groups[2].Value;

                JavaAttr attr = new JavaAttr(this, name, type);
                this.attributes.Add(attr);
            }

        }

        public List<JavaAttr> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }
    }
}
