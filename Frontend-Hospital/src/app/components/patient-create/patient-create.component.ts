import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-patient-create',
  templateUrl: './patient-create.component.html',
  styleUrls: ['./patient-create.component.css']
})
export class PatientCreateComponent implements OnInit {

  patient = {
    name: '',
    fileNo: '',
    citizenId: '',
    birthDate: '',
    gender: '',
    natinality: '',
    phoneNumber: '',
    email: '',
    country: '',
    city: '',
    street: '',
    address1: '',
    address2: '',
    contactPerson: '',
    contactRelation: '',
    contactPhone: '',
    firstVisitDate: '',
    available: false
  };
  submitted = false;

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
  }

  createPatient(): void {
    const data = {
      name: this.patient.name,
      fileNo: this.patient.fileNo,
      citizenId: this.patient.citizenId,
      birthDate: this.patient.birthDate,
      gender: this.patient.gender,
      natinality: this.patient.natinality,
      phoneNumber: this.patient.phoneNumber,
      email: this.patient.email,
      country: this.patient.country,
      city: this.patient.city,
      street: this.patient.street,
      address1: this.patient.address1,
      address2: this.patient.address2,
      contactPerson: this.patient.contactPerson,
      contactRelation: this.patient.contactRelation,
      contactPhone: this.patient.contactPhone,
      firstVisitDate: this.patient.firstVisitDate,
    };

    this.patientService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newPatient(): void {
    this.submitted = false;
    this.patient = {
      name: '',
      fileNo: '',
      citizenId: '',
      birthDate: '',
      gender: '',
      natinality: '',
      phoneNumber: '',
      email: '',
      country: '',
      city: '',
      street: '',
      address1: '',
      address2: '',
      contactPerson: '',
      contactRelation: '',
      contactPhone: '',
      firstVisitDate: '',
      available: false
    };
  }

}