import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Guid} from '../helpers/helpers';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private actionUrl: string;
  constructor(private http: HttpClient ) { }

  public setUrl(url: string) {
    const API_URL = 'https://localhost:5001';
    this.actionUrl = API_URL + '/api' + url;

  }

  public getAll<T>(): Observable<T> {
    console.log(this.actionUrl);
    return this.http.get<T>(this.actionUrl, {headers: new HttpHeaders({'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'})});
  }

  public getSingle<T>(id: Guid): Observable<T> {
    return this.http.get<T>(this.actionUrl + id, {headers: new HttpHeaders({'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'})});
  }

  public getSingleObj<T>(obj: any): Observable<T> {
    return this.http.get<T>(this.actionUrl, {headers: new HttpHeaders({'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'})});
  }

  public post<T>(obj: any): Observable<T> {
    return this.http.post<T>(this.actionUrl, obj, {headers: new HttpHeaders({'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'})});
  }

  public update<T>(id: number, itemToUpdate: any): Observable<T> {
    return this.http
      .put<T>(this.actionUrl + id, itemToUpdate, {headers: new HttpHeaders({'Content-Type': 'application/json',
          'Access-Control-Allow-Origin': '*'})});
  }

  public delete<T>(id: Guid): Observable<T> {
    return this.http.delete<T>(this.actionUrl + id, {headers: new HttpHeaders({'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'})});
  }
}
