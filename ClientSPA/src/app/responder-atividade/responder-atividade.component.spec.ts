import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponderAtividadeComponent } from './responder-atividade.component';

describe('ResponderAtividadeComponent', () => {
  let component: ResponderAtividadeComponent;
  let fixture: ComponentFixture<ResponderAtividadeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ResponderAtividadeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ResponderAtividadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
