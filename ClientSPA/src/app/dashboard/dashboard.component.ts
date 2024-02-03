import { Component, inject } from '@angular/core';
import { SampleApiService } from '../sample-api.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  sampleApiService: SampleApiService = inject(SampleApiService)

  getWeather() {
    this.sampleApiService.getWeatherForecast().subscribe(result => console.log(result))
  }
}
