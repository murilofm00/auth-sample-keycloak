import { Component, OnInit, inject } from '@angular/core';
import { SampleApiService } from '../sample-api.service';
import { Atividade } from '../models/atividade';

@Component({
  selector: 'app-responder-atividades',
  templateUrl: './responder-atividades.component.html',
  styleUrl: './responder-atividades.component.css'
})
export class ResponderAtividadesComponent implements OnInit {
  private sampleApiService: SampleApiService = inject(SampleApiService)
  atividades: Atividade[] = [];

  ngOnInit() {
    this.sampleApiService.getAtividades().subscribe(result => {
      console.log(result)
      this.atividades = result
    })
  }
}
