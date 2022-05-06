﻿using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hospital.Repository
{
    public class PrescriptionRepository
    {
        private const string NOT_FOUND_ERROR = "Prescription with {0}:{1} can not be found!";
        private const string fileName = "prescription.txt";
        public PrescriptionRepository () { }

        public Prescription createPrescription(Prescription newPrescription)
        {
            Serializer<Prescription> prescriptionSerializer = new Serializer<Prescription>();
            Prescription prescription = new Prescription(newPrescription.Id,newPrescription.BeginOfUse, newPrescription.PeriodInDays);
            prescription.setMedicines(newPrescription.getMedicines());
            prescriptionSerializer.oneToCSV(fileName, prescription);
            return prescription;
        }

        public Boolean updatePrescription(Prescription newPrescription)
        {
            List<Prescription> prescriptions = showPrescriptions();
            foreach(Prescription prescription in prescriptions)
            {
                if(prescription.Id == newPrescription.Id)
                {
                    prescription.PeriodInDays = newPrescription.PeriodInDays;
                    prescription.setMedicines(newPrescription.getMedicines());
                    Serializer<Prescription> prescriptionSerializer = new Serializer<Prescription>();
                    prescriptionSerializer.toCSV(fileName, prescriptions);
                    return true;
                }
            }
            return false;
        }
        public List<Prescription> showPrescriptions()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            Serializer<Prescription> prescriptiontSerializer = new Serializer<Prescription>();
            prescriptions = prescriptiontSerializer.fromCSV(fileName);
            return prescriptions;
        }

        public Prescription getPrescription(int id)
        {
            try
            {
                {
                    return showPrescriptions().SingleOrDefault(prescription => prescription.Id == id);
                }
            }
            catch (ArgumentException)
            {
                {

                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id), null);

                }
            }
        }
    }
}