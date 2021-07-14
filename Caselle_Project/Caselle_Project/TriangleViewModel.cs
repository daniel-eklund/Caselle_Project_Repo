using System.ComponentModel;

namespace Caselle_Project
{
    class TriangleViewModel : INotifyPropertyChanged
    {
        private Triangle _triangle;
        public event PropertyChangedEventHandler PropertyChanged;

        // Default instance of a triangle view model
        public TriangleViewModel()
        {
            _triangle = new Triangle { };
            output = "";
        }

        public Triangle Triangle
        {
            get { return _triangle; }
            set { _triangle = value; }
        }

        public string output
        {
            set; get;
        }

        public string s1
        {
            get { return Triangle.s1; }
            set
            {
                if (Triangle.s1 != value)
                {
                    Triangle.s1 = value;
                    OnPropertyChanged("s1");
                    update();
                }
            }
        }

        public string s2
        {
            get { return Triangle.s2; }
            set
            {
                if (Triangle.s2 != value)
                {
                    Triangle.s2 = value;
                    OnPropertyChanged("s2");
                    update();
                }
            }
        }

        public string s3
        {
            get { return Triangle.s3; }
            set
            {
                if (Triangle.s3 != value)
                {
                    Triangle.s3 = value;
                    OnPropertyChanged("s3");
                    update();
                }
            }
        }

        // Returns a string based on angles
        private string strAngles()
        {
            double[] angs = Triangle.Angles();
            if (Triangle.Valid() == "an invalid") return "";
            return $"\nAngles: {angs[0]}°, {angs[1]}°, {angs[2]}°";
        }
        
        // Returns a string based on area
        private string strArea()
        {
            double area = Triangle.Area();
            if (double.IsNaN(area) || area == 0) return "";
            return $"\nArea: { area}";
        }

        // Check and update text banner
        public void update()
        {
            if (this.s1 != "" && this.s2 != "" && this.s3 != "")
            {
                output = $"These sides produce {Triangle.Type()} triangle {this.strAngles()}{this.strArea()}";
                OnPropertyChanged("output");
            } else
            {
                output = "";
                OnPropertyChanged("output");
            }
        }



        // Code used from:
            // https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8#:~:text=To%20implement%20INotifyPropertyChanged%20you%20need,whenever%20the%20property%20is%20updated.
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
