﻿using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Windows;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for KreiranjeNovogNaloga.xaml
    /// </summary>
    public partial class KreiranjeNovogNaloga : Window
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        public KreiranjeNovogNaloga()
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            InitializeComponent();
        }

        private void nazad(object sender, RoutedEventArgs e)
        {
            var pacijenti = new Pacijenti();
            pacijenti.Show();
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            var pacijenti = new Pacijenti();
            pacijenti.Show();
            this.Close();
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {

            string ime = imeBox.Text;
            string prezime = prezimeBox.Text;
            string email = emailBox.Text;
            string telefon = telefonBox.Text;
            string jmbg = jmbgBox.Text;
            string lbo = lboBox.Text;
            string datum = datumBox.Text;
            string drzava = drzavaBox.Text;
            string mesto = mestoBox.Text;
            string adresa = adresaBox.Text;

            Patient patient = patientController.CreatePatient(ime, prezime, Gender.Genders.No_Gender, email, telefon, jmbg, lbo, DateTime.Parse(datum), drzava, mesto, adresa);



            /*string ime = "Bogdan";
            string prezime = "Blagojevic";
            string email = "boki@gmail.com";
            string telefon = "0642345678";
            string jmbg = "2308000607088";
            string lbo = "12345654321";
            string datum = "23/08/2000";
            string drzava = "Srbija";
            string mesto = "Novi Sad";
            string adresa = "Neka";*/

        }
    }
}
