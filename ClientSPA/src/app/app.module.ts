import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KeycloakAngularModule, KeycloakService } from 'keycloak-angular';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { ResponderAtividadeComponent } from './responder-atividade/responder-atividade.component';
import { FormsModule } from '@angular/forms';
import { ResponderAtividadesComponent } from './responder-atividades/responder-atividades.component';
import { GestaoAtividadesComponent } from './gestao-atividades/gestao-atividades.component';
import { ControleAtividadeComponent } from './controle-atividade/controle-atividade.component';

function initializeKeycloak(keycloak: KeycloakService) {
  return () =>
    keycloak.init({
      config: {
        url: 'http://localhost:8080',
        realm: 'my-realm',
        clientId: 'my-angular-client',
        //realm: 'app-sample',
        //clientId: 'auth-app-sample',
      },
      initOptions: {
        onLoad: 'check-sso',
        silentCheckSsoRedirectUri:
          window.location.origin + '/assets/silent-check-sso.html',
      },
      enableBearerInterceptor: true
    });
}

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ResponderAtividadeComponent,
    ResponderAtividadesComponent,
    GestaoAtividadesComponent,
    ControleAtividadeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    KeycloakAngularModule,
    FormsModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initializeKeycloak,
      multi: true,
      deps: [KeycloakService]
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
