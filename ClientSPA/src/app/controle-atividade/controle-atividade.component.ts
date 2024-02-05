import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { Atividade } from '../models/atividade';
import { SampleApiService } from '../sample-api.service';

@Component({
  selector: 'app-controle-atividade',
  templateUrl: './controle-atividade.component.html',
  styleUrl: './controle-atividade.component.css'
})
export class ControleAtividadeComponent {
  @Input({ required: true }) atividade!: Atividade
  @Output() atividadeRemovida = new EventEmitter()

  sampleApiService: SampleApiService = inject(SampleApiService)

  removerAtividade() {
    this.sampleApiService.deleteAtividade(this.atividade.id).subscribe(() => {
      console.log("removido");
      this.atividadeRemovida.emit(true);
    })
  }
}
