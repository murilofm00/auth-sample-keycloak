import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SampleApiService {

  url = 'https://localhost:53438'
  constructor(private http: HttpClient) { }

  getWeatherForecast() {
    return this.http.get(this.url + '/WeatherForecast');
  }

}
