import { ComponentFixture, TestBed } from "@angular/core/testing";
import { PatrimonioCadastroComponent } from "./patrimonioCadastro.component";


describe("PatrimonioCadastroComponent", () => {
  let component: PatrimonioCadastroComponent;
  let fixture: ComponentFixture<PatrimonioCadastroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PatrimonioCadastroComponent],
    });
    fixture = TestBed.createComponent(PatrimonioCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
