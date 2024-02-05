import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Atividade } from './models/atividade';
import { Participacao } from './models/participacao';

@Injectable({
  providedIn: 'root'
})
export class SampleApiService {

  url = 'https://localhost:5001';
  constructor(private http: HttpClient) { }

  getAtividades() {
    return this.http.get<Atividade[]>(this.url + '/Atividade');
  }

  getParticipacao(idAtividade: string) {
    return this.http.get<Participacao>(this.url + '/Participacao/' + idAtividade)
  }

  putParticipacao(participacao: Participacao) {
    return this.http.put(this.url + '/Participacao/' + participacao.idAtividade, participacao);
    //return this.http.put(this.url + '/Participacao', participacao, {
    //  params: { idAtividade: participacao.idAtividade }
    //});
  }

  deleteAtividade(idAtividade: string) {
    return this.http.delete(this.url + '/Atividade/' + idAtividade)
  }

}
