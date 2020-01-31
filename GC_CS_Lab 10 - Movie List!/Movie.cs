using System;
using System.Collections.Generic;
using System.Text;

namespace GC_CS_Lab_10___Movie_List_
{
    class Movie
    {
        #region fields
        // fields
        private string title;
        private string category;
        #endregion

        #region properties
        // properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        #endregion

        #region constructors
        // constructors
        //default constructor
        public Movie () { }

        public Movie(string _title, string _category)
        {
            title = _title;
            category = _category;
        }
        #endregion

        #region methods
        // methods
        #endregion
    }
}
