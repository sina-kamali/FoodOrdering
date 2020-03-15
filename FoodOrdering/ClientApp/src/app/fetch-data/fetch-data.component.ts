import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ModalService} from '../modal-dialog/modal.service';
import {RestaurantService} from '../services/restaurant.service';
import {Restaurants} from "../shared/modals/Restaurants";
import {Guid} from "../helpers/helpers";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private modalService: ModalService, private restauran: RestaurantService) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  test() {
    // this.modalService.success('test', 'title');
    const obj: Restaurants = {NAME: 'restaurant 2', ID: Guid.newGuid().toString()};

    const result = this.restauran.Add(obj);
    console.log(result);
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
