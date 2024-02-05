import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponderAtividadesComponent } from './responder-atividades.component';

describe('ResponderAtividadesComponent', () => {
  let component: ResponderAtividadesComponent;
  let fixture: ComponentFixture<ResponderAtividadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ResponderAtividadesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ResponderAtividadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
