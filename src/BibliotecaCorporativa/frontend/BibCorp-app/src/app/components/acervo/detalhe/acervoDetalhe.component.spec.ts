import { ComponentFixture, TestBed } from "@angular/core/testing";
import { AcervoDetalheComponent } from "./acervoDetalhe.component";


describe("AcervoDetalheComponent", () => {
  let component: AcervoDetalheComponent;
  let fixture: ComponentFixture<AcervoDetalheComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AcervoDetalheComponent],
    });
    fixture = TestBed.createComponent(AcervoDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
