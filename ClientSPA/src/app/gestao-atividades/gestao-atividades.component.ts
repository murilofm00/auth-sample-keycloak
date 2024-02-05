import { Component, OnInit, inject } from '@angular/core';
import { Atividade } from '../models/atividade';
import { SampleApiService } from '../sample-api.service';

@Component({
  selector: 'app-gestao-atividades',
  templateUrl: './gestao-atividades.component.html',
  styleUrl: './gestao-atividades.component.css'
})
export class GestaoAtividadesComponent implements OnInit {
  private sampleApiService: SampleApiService = inject(SampleApiService)
  atividades: Atividade[] = [];

  ngOnInit() {
    this.sampleApiService.getAtividades().subscribe(result => {
      console.log(result)
      this.atividades = result
    })
  }

  atividadeRemovida(id: string) {
    console.log(id);
    this.atividades = this.atividades.filter(atividade => atividade.id != id)
  }
}
