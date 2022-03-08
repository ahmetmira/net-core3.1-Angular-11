import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {

  patients: any;
  currentPatient = null;
  currentIndex = -1;
  name = '';

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.readPatients();
  }

  readPatients(): void {
    this.patientService.readAll()
      .subscribe(
        (patients: any[])=> {
          this.patients = patients;
          console.log(patients);
        },
        error => {
          console.log(error);
        });
  }

  refresh(): void {
    this.readPatients();
    this.currentPatient = null;
    this.currentIndex = -1;
  }

  setCurrentPatient(patient: null, index: number): void {
    this.currentPatient = patient;
    this.currentIndex = index;
  }

  deleteAllPatients(): void {
    this.patientService.deleteAll()
      .subscribe(
        response => {
          console.log(response);
          this.readPatients();
        },
        error => {
          console.log(error);
        });
  }

  searchByName(): void {
    this.patientService.searchByName(this.name)
      .subscribe(
        patients => {
          this.patients = patients;
          console.log(patients);
        },
        error => {
          console.log(error);
        });
  }
}
