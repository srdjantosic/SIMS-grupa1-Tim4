/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hospital.Repository
{
    public class PatientRepository
    {
        private const string NOT_FOUND_ERROR = "Patient with {0}:{1} can not be found!";
        public PatientRepository() { }

        public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, System.DateTime birthday, String country, String city, String adress)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            Patient patient = new Patient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
            patientSerializer.oneToCSV("patients.txt", patient);
            return GetPatient(patient.Lbo);
        }

        
        public Boolean UpdatePatient(String lbo, String firstName, String lastName, Gender.Genders gender, DateTime birthday, String email, String phoneNumber, String country, String city, String adress)
        {
            List<Patient> patients = new List<Patient>();
            patients = ShowPatients();
            foreach (Patient patient in patients)
            {
                if (patient.Lbo == lbo)
                {
                    if (firstName.Length != 0)
                    {
                        patient.FirstName = firstName;
                    }
                    if (lastName.Length != 0)
                    {
                        patient.LastName = lastName;
                    }
                    patient._Gender = gender;
                    patient.Birthday = birthday;
                    if (email.Length != 0)
                    {
                        patient.Email = email;
                    }
                    if (phoneNumber.Length != 0)
                    {
                        patient.PhoneNumber = phoneNumber;
                    }
                    if (country.Length != 0)
                    {
                        patient.Country = country;
                    }
                    if (city.Length != 0)
                    {
                        patient.City = city;
                    }
                    if (adress.Length != 0)
                    {
                        patient.Adress = adress;
                    }
                    Serializer<Patient> patientSerializer = new Serializer<Patient>();
                    patientSerializer.toCSV("patients.txt", patients);

                    return true;
                }

            } throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));
        }
        

        public List<Patient> ShowPatients()
        {
            List<Patient> patients = new List<Patient>();
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patients = patientSerializer.fromCSV("patients.txt");
            return patients;
        }

        public Boolean DeletePatient(String lbo)
        {
            List<Patient> patients = new List<Patient>();
            patients = ShowPatients();

            foreach (Patient patient in patients)
            {
                if (patient.Lbo == lbo)
                {
                    if (patients.Remove(patient))
                    {
                        Serializer<Patient> patientSerializer = new Serializer<Patient>();
                        patientSerializer.toCSV("patients.txt", patients);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            } throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));

        }


        public Patient GetPatient(String lbo)
        {
            try
            {
                {
                    return ShowPatients().SingleOrDefault(patient => patient.Lbo == lbo);
                }
            }
            catch(ArgumentException)
            {
                {

                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo), null);

                }
            }
        }
             
    }

}