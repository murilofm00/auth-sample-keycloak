import { Component, inject} from '@angular/core';
import { KeycloakService } from 'keycloak-angular';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  keycloakService: KeycloakService = inject(KeycloakService)

  roles = this.keycloakService.getUserRoles()
}
