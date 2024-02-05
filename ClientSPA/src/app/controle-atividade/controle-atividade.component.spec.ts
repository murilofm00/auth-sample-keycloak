import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControleAtividadeComponent } from './controle-atividade.component';

describe('ControleAtividadeComponent', () => {
  let component: ControleAtividadeComponent;
  let fixture: ComponentFixture<ControleAtividadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ControleAtividadeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ControleAtividadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
