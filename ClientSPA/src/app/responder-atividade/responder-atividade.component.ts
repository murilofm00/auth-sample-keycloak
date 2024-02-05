import { Component, Input, inject } from '@angular/core';
import { Atividade } from '../models/atividade';
import { Participacao } from '../models/participacao';
import { KeycloakService } from 'keycloak-angular';
import { SampleApiService } from '../sample-api.service';

@Component({
  selector: 'app-responder-atividade',
  templateUrl: './responder-atividade.component.html',
  styleUrl: './responder-atividade.component.css'
})
export class ResponderAtividadeComponent {
  @Input({ required: true }) atividade!: Atividade
  @Input() index: number = 1

  private readonly keycloakService: KeycloakService = inject(KeycloakService)
  private readonly sampleApiService: SampleApiService = inject(SampleApiService)


  resposta: string = ''
  responder = false

  responderAvaliacao() {
    this.sampleApiService
      .getParticipacao(this.atividade.id)
      .subscribe(result => {
        if (result) {
          this.resposta = result.resposta;
        } else {
          this.resposta = '';
        }
        this.responder = true;
      })
  }

  atualizarParticipacao() {
    const participacao: Participacao = {
      idAtividade: this.atividade.id,
      idUsuario: this.obterIdUsuario() || "",
      resposta: this.resposta
    }

    this.sampleApiService
      .putParticipacao(participacao)
      .subscribe(() => {
        this.responder = false
      }, error => console.log(error));

  }

  obterIdUsuario() {
    if (!this.keycloakService.isLoggedIn()) {
      return undefined
    }

    return this.keycloakService.getKeycloakInstance().subject;
  }
}
