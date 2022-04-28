/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;

namespace Project.Hospital.Service
{
    public class PatientService
    {

        private PatientRepository patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, System.DateTime birthday, String country, String city, String adress)
        {

            if (firstName.Length == 0 || lastName.Length == 0 || jmbg.Length == 0 || lbo.Length == 0)
            {
                return null;
            }
            else
            {
                if (GetPatient(lbo) == null)
                {
                    return patientRepository.CreatePatient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
                }
                else
                {
                    return null;
                }
            }

        }


        public Boolean UpdatePatient(String lbo, String firstName, String lastName, Gender.Genders gender, DateTime birthday, String email, String phoneNumber, String country, String city, String adress)
        {
            return patientRepository.UpdatePatient(lbo, firstName, lastName, gender, birthday, email, phoneNumber, country, city, adress);
        }

        public List<Patient> ShowPatients()
        {
            return patientRepository.ShowPatients();
        }


        public Boolean DeletePatient(String lbo)
        {
            return patientRepository.DeletePatient(lbo);
        }

        public Patient GetPatient(String lbo)
        {
            return patientRepository.GetPatient(lbo);
        }

    }
}