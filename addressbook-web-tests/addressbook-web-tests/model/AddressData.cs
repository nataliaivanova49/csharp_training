using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class AddressData : IEquatable<AddressData>, IComparable<AddressData>
    {
        private string allPhones;
        private string allMails;
        private string addressDataFromPage;
        private string Name;
        private string Block1;
        protected string firstname;
        protected string middlename = "";
        protected string lastname;
        protected string nickname = "";
        protected string title = "";
        protected string company = "";
        protected string address = "";
        protected string home = "";
        protected string mobile = "";
        protected string work = "";
        protected string fax = "";
        protected string email = "";
        protected string email2 = "";
        protected string email3 = "";
        protected string homepage = "";
        protected string bday = "";
        protected string bmonth = "";
        protected string byear = "";
        protected string aday = "";
        protected string amonth = "";
        protected string ayear = "";
        protected string groupselection = "";
        protected string address2 = "";
        protected string phone2 = "";
        protected string notes = "";

        public AddressData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public AddressData()
        {
         
        }
        public bool Equals(AddressData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public int CompareTo(AddressData other)
        {
            if (Lastname == other.Lastname)
            {                
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }



        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        
        [Column(Name = "nickname")]
        public string Nickname { get; set; }
        
        [Column(Name = "title")]
        public string Title { get; set; }
        
        [Column(Name = "company")]
        public string Company { get; set; }
        
        [Column(Name = "address")]
        public string Address { get; set; }
        
        [Column(Name = "home")]
        public string Home { get; set; }
        
        [Column(Name = "mobile")]
        public string Mobile { get; set; }
        
        [Column(Name = "work")]
        public string Work { get; set; }
        
        [Column(Name = "fax")]
        public string Fax { get; set; }
        
        [Column(Name = "email")]
        public string Email { get; set; }
        
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        
        [Column(Name = "bday")]
        public string Bday { get; set; }
        
        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }
        
        [Column(Name = "byear")]
        public string Byear { get; set; }
        
        [Column(Name = "aday")]
        public string Aday { get; set; }
        
        [Column(Name = "amonth")]
        public string Amonth { get; set; }
        
        [Column(Name = "ayear")]
        public string Ayear { get; set; }
        
      
        public string Groupselection { get; set; }
        
        [Column(Name = "address2")]
        public string Address2 { get; set; }
        
        [Column(Name = "phone2")]
        public string Phone2 { get; set; }
        
        [Column(Name = "notes")]
        public string Notes { get; set; }
       
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<AddressData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Address select g).ToList();
            }
        }
        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                    return (CleanUpPhone(Home) + CleanUpPhone(Mobile) + CleanUpPhone(Work) + CleanUpPhone(Phone2)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            } 
        }
        private string CleanUpPhone(string phone) 
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else 
            {
                return Regex.Replace(phone,"[ -()]","") + "\r\n";
            }
        }
        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return (ReadyText(Email) + ReadyText(Email2) + ReadyText(Email3)).Trim();

                }
            }
            set
            {
                allMails = value;
            }
        }
        private string ReadyText(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return text + "\r\n";
            }
        }
        public string AddressDataFromPage
        {
            get
            {
                if (addressDataFromPage != null)
                {
                    return addressDataFromPage;
                }
                else
                {
                    Name = (FullName(Firstname) + FullName(Middlename) + FullName(Lastname)).Trim();
                    Block1 = ReadyText(Name) + ReadyText(Nickname) + ReadyText(Title) + ReadyText(Address);
                    if (CleanUpPhone(Home) != "")
                    {
                        string CleanUpHome = CleanUpPhone(Home);
                        Home = "H: " + CleanUpHome;
                    }

                    if (CleanUpPhone(Mobile) != "")
                    {
                         string CleanUpMobile = CleanUpPhone(Mobile);
                         Mobile = "M: " + CleanUpMobile;
                    }
                    if (CleanUpPhone(Work) != "")
                    {
                         string CleanUpWork = CleanUpPhone(Work);
                         Work = "W: " + CleanUpWork;
                    }

                    if (CleanUpPhone(Fax) != "")
                    {
                        string CleanUpFax = CleanUpPhone(Fax);
                        Fax = "F: " + CleanUpFax;
                    }

                    string PhonesFax = Home + Mobile + Work + Fax;

                    if(ReadyText(Homepage) != "")
                    {
                        Homepage = "Homepage:\r\n" + Homepage;
                    }

                    string MailsHomepage = ReadyText(Email) + ReadyText(Email2) + ReadyText(Email3) + ReadyText(Homepage);

                    DateTime dateNow = DateTime.Now;
                    if (Byear == null || Byear == "")
                    {
                        Byear = "";
                    }
                    else
                    {
                        int bYearInt = int.Parse(Byear);
                        int year = dateNow.Year - bYearInt;
                        string stringyear = year.ToString();
                        Byear = Byear + " (" + stringyear + ")";
                    };

                    if (Ayear == null || Ayear == "" || Ayear == "-")
                    {
                        Ayear = "";
                    }
                    else
                    {
                        int aYearInt = int.Parse(Ayear);
                        int yearA = dateNow.Year - aYearInt;
                        string stringyearA = yearA.ToString();
                        Ayear = Ayear + " (" + stringyearA + ")";
                    };

                    if (Bmonth == null || Bmonth == "" || Bmonth == "-" )
                    {
                        Bmonth = "";
                    }

                    if (Amonth == null || Amonth == "" || Amonth == "-")
                    {
                        Amonth = "";
                    }

                    if (Bday == null || Bday == "" ||Bday == "-" || Bday == "0")
                    {
                        Bday = "";
                    }
                    else
                    {
                        Bday = Bday + ".";                    
                    };
                    if (Aday == null || Aday == "" || Aday == "-" || Aday == "0")
                    {
                        Aday = "";
                    }
                    else
                    {
                        Aday = Aday + ".";
                    };
                    string BirthDayFully = (FullName(Bday) + FullName(Bmonth) + FullName(Byear)).Trim();
                    if (BirthDayFully != "") 
                    {
                        BirthDayFully = "Birthday " + BirthDayFully;
                    };
                    string AnniversaryDayFully = (FullName(Aday) + FullName(Amonth) + FullName(Ayear)).Trim();
                    if (AnniversaryDayFully != "")
                    {
                        AnniversaryDayFully = "Anniversary " + AnniversaryDayFully;
                    };
                    if (CleanUpPhone(Phone2) != "")
                    {
                        string CleanUpPhone2 = CleanUpPhone(Phone2);
                        Phone2 = "P: " + CleanUpPhone2;
                    }

                    return (ReadyText(Block1) + ReadyText(PhonesFax) + ReadyText(MailsHomepage) + ReadyText(ReadyText(BirthDayFully) + ReadyText(AnniversaryDayFully)) + ReadyText(Address2) + "\r\n" + ReadyText(Phone2) + ReadyText(Notes)).Trim();

                }
            }
            set
            {
                addressDataFromPage = value;
            }
        }

        private string FullName(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            else
            {
                return name + " ";
            }
    }
}
}

