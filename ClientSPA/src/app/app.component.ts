import { Component, OnInit, inject } from '@angular/core';
import { KeycloakEventType, KeycloakService } from 'keycloak-angular';
import { SampleApiService } from './sample-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  name = '<>';
  keycloakService: KeycloakService = inject(KeycloakService)
  isLoggedIn = false

  ngOnInit(): void {
    this.updateUserInfo();
    this.keycloakService.keycloakEvents$.subscribe(event => {
        this.updateUserInfo();
    });
  }

  logout(): void {
    this.keycloakService.logout();
  }

  login(): void {
    this.keycloakService.login();
  }


  async updateUserInfo() {
    this.isLoggedIn = this.keycloakService.isLoggedIn();
    if (this.isLoggedIn) {
      const userInfo = await this.keycloakService.loadUserProfile();
      console.log("userInfo", userInfo);
      const name = `${userInfo.firstName} ${userInfo.lastName}`;
      this.name = name;
    } else {
      this.name = '';
    }
  }

}