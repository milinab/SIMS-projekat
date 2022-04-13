using ClassDiagram.Model;
using Hospital.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;



namespace Hospital.Manager {
    
    


    public partial class ManagerWindow : Window {





        /*Room bowser = new Room("Bowser", "Nesto");

        
        Stream stream = File.Open("RoomData.dat", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();*/

        //formatter.Serialize(bowser, stream);
        public ObservableCollection<Equipment> Equipments
        {
            get;
            set;
        }

        public ObservableCollection<String> Types
        {
            get;
            set;
        }

        public ObservableCollection<Room> Rooms
        {
            get;
            set;
        }

        private DelegateCommand<Room> _deleteCommand;
        public DelegateCommand<Room> DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand<Room>(ExecuteDeleteCommand));

        void ExecuteDeleteCommand(Room parameter)
        {
            Rooms.Remove(parameter);
        }

 


        public ManagerWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Rooms = new ObservableCollection<Room>();
            Equipments = new ObservableCollection<Equipment>();
            Types = new ObservableCollection<String>();


            Equipment eq1 = new Equipment("123",3, "Makaze");
            Equipment eq2 = new Equipment("222", 2, "Noz");
            Equipment eq3 = new Equipment("333", 1, "Skener");

            
            Equipments.Add(eq1);
            Equipments.Add(eq2);
            Equipments.Add(eq3);

           


            Types.Add("Operation");
            Types.Add("Conference");
            Types.Add("Storage");


            


        

            Rooms.Add(new Room("12", new Equipment("123", 3, "Makaze"), "Operation"));
            Rooms.Add(new Room("1a", new Equipment("222", 2, "Noz"), "Conference"));
            Rooms.Add(new Room("14g", new Equipment("333", 1, "Skener"), "Storage"));





        }



        private void EditRoomClick(object sender, RoutedEventArgs e)
        {
        }
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
           
            Rooms.Add(new Room { Id = TextBox.Text, Equipment = new Equipment("",2, eqComboBox.Text), Type = eqComboBox2.Text });
        }

        private void dataGridRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        





        /*      public void GetObjectData(SerializationInfo info, StreamingContext context)
              {
                  info.AddValue("Id", r.Id );
                  info.AddValue("Equipment", r.Equipment);
              }

              public ManagerWindow(SerializationInfo info, StreamingContext context)
              {
                  r.Id = (string)info.GetValue("Id", typeof(string));
                  r.Equipment = (string)info.GetValue("Equimpent", typeof(string));
              }*/
    }
}
