import { Injectable } from '@angular/core';
import {ApiService} from './api.service';
import {Restaurants} from '../shared/modals/Restaurants';
import {Guid} from '../helpers/helpers';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  constructor(private apiService: ApiService) { }

  public GetAll(): Promise<any> {
    let allRestaurants: Restaurants[];
    this.apiService.setUrl('/Restaurants/GetAllRestaurants');

    return new Promise((resolve, reject) => {
      this.apiService
        .getAll<Restaurants[]>()
        .subscribe((data: any[]) => {
          allRestaurants = data;
          resolve(allRestaurants);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }

  public Get(id: Guid): Promise<any> {
    let restaurant: Restaurants;
    this.apiService.setUrl('/Restaurants/GetRestaurant');

    return new Promise((resolve, reject) => {
      this.apiService
        .getSingle<Restaurants>(id)
        .subscribe((data: any) => {
          restaurant = data;
          resolve(restaurant);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }


  public Find(restaurant: Restaurants): Promise<any> {
    let res: Restaurants;
    this.apiService.setUrl('/Restaurants/FindRestaurant');
    return new Promise((resolve, reject) => {
      this.apiService
        .post<Restaurants>(restaurant)
        .subscribe((data: any) => {
          res = data;
          resolve(res);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }


  public Update(restaurant: Restaurants): Promise<any> {
    let res: Restaurants;
    this.apiService.setUrl('/Restaurants/UpdateRestaurant');
    return new Promise((resolve, reject) => {
      this.apiService
        .post<Restaurants>(restaurant)
        .subscribe((data: any) => {
          res = data;
          resolve(res);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }


  public Delete(restaurant: Restaurants): Promise<any> {
    let res: Restaurants;
    this.apiService.setUrl('/Restaurants/GetRestaurant');
    return new Promise((resolve, reject) => {
      this.apiService
        .post<Restaurants>(restaurant)
        .subscribe((data: any) => {
          res = data;
          resolve(res);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }

  public DeleteById(id: Guid): Promise<any> {
    let res: Restaurants;
    this.apiService.setUrl('/Restaurants/DeleteRestaurants');
    return new Promise((resolve, reject) => {
      this.apiService
        .delete<Restaurants>(id)
        .subscribe((data: any) => {
          res = data;
          resolve(res);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }

  public Add(restaurant: Restaurants): Promise<any> {
    let res: Restaurants;
    this.apiService.setUrl('/Restaurants/AddRestaurant');
    return new Promise((resolve, reject) => {
      this.apiService
        .post<Restaurants>(restaurant)
        .subscribe((data: any) => {
          res = data;
          resolve(res);
        }, error => () => {
          console.log(error);
          reject(error);
        }, () => {
          console.log('Done!');
        });
    });
  }
}
