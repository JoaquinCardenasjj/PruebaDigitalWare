import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CreateFacturacionesComponent } from './create-facturaciones.component';



describe('CreateFacturacionesComponent', () => {
  let component: CreateFacturacionesComponent;
  let fixture: ComponentFixture<CreateFacturacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateFacturacionesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateFacturacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
