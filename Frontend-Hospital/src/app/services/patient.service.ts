import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseURL = 'https://localhost:44379/api/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private httpClient: HttpClient) { }

  readAll(): Observable<any> {
    return this.httpClient.get(baseURL);
  }

  read(id: any): Observable<any> {
    return this.httpClient.get(`${baseURL}/${id}`);
  }

  create(data: { name: string; fileNo: string; citizenId: string; birthDate: string; gender: string; natinality: string; phoneNumber: string; email: string; country: string; city: string; street: string; address1: string; address2: string; contactPerson: string; contactRelation: string; contactPhone: string; firstVisitDate: string; }): Observable<any> {
    return this.httpClient.post(baseURL, data);
  }

  update(id: any, data: {
      name: any; fileNo: any; citizenId: any; birthDate: any; gender: any; natinality: any; phoneNumber: any; email: any; country: any; city: any; street: any //localhost:44397/api/patients';
        ; address1: any; address2: any; contactPerson: any; contactRelation: any; contactPhone: any; firstVisitDate: any; available: any;
    }): Observable<any> {
    return this.httpClient.put(`${baseURL}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.httpClient.delete(`${baseURL}/${id}`);
  }

  deleteAll(): Observable<any> {
    return this.httpClient.delete(baseURL);
  }

  searchByName(name: string): Observable<any> {
    return this.httpClient.get(`${baseURL}?name=${name}`);
  }
}
