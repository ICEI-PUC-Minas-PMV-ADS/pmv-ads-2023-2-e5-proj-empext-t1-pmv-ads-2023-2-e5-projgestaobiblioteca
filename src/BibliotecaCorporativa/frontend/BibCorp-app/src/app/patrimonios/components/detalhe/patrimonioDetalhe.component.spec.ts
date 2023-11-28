import { ComponentFixture, TestBed } from "@angular/core/testing";
import { PatrimonioDetalheComponent } from "./patrimonioDetalhe.component";

describe("PatrimonioDetalheComponent", () => {
  let component: PatrimonioDetalheComponent;
  let fixture: ComponentFixture<PatrimonioDetalheComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PatrimonioDetalheComponent],
    });
    fixture = TestBed.createComponent(PatrimonioDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
