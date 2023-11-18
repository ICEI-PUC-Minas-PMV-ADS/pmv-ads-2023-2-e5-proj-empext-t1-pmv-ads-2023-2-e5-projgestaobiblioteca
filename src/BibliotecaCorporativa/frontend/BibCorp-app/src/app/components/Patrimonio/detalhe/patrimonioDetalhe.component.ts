import { Component } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";

import { Acervo, Patrimonio } from "src/app/models";
import { AcervoService, PatrimonioService } from "src/app/services";
import { FormValidator } from "src/app/util";

@Component({
  selector: "app-patrimonioDetalhe",
  templateUrl: "./patrimonioDetalhe.component.html",
  styleUrls: ["./patrimonioDetalhe.component.scss"],
})
export class PatrimonioDetalheComponent {
  public formPatrimonio: FormGroup;

  public acervo: Acervo;
  public patrimonio: Patrimonio;
  public patrimonioParam: any = "";

  public editMode: Boolean = false;

  public capaPatrimonio: string = "../../../../assets/Images/capaDefault.png";

  public get ctrF(): any {
    return this.formPatrimonio.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private formBuilder: FormBuilder,
    private acervoService: AcervoService,
    private patrimonioService: PatrimonioService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {
    this.patrimonioParam = this.activevateRouter.snapshot.paramMap.get("id");
    this.editMode = this.patrimonioParam != null ? true : false;

    this.formValidator();

    if (this.editMode) this.getPatrimonio();
  }

  public formValidator(): void {
    this.formPatrimonio = this.formBuilder.group({
      patrimonioId: [""],
      isbn: [
        "",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(13),
        ],
      ],
      localizacao: [""],
      sala: [""],
      coluna: [""],
      prateleira: [""],
      posicao: [""],
      dataCadastro: [""],
      dataAtualizacao: [""],
      dataIndisponibilidade: [""],
      statusTela: [!this.editMode ? "Liberado" : ""],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formPatrimonio.reset();
  }

  public saveChange(): void {
    if (this.formPatrimonio.valid)
      if (!this.editMode) {
        this.novoPatrimonio();
      } else {
        this.salvarPatrimonio();
      }
  }

  public getPatrimonio(): void {
    this.spinnerService.show();

    this.patrimonioService
      .getPatrimonioById(+this.patrimonioParam)
      .subscribe(
        (patrimonio: Patrimonio) => {
          this.patrimonio = patrimonio;

          this.formPatrimonio.patchValue(this.patrimonio);
          this.ctrF.patrimonioId.setValue(this.patrimonio.id);
          this.ctrF.statusTela.setValue(
            this.patrimonio.status ? "Emprestado" : "Liberado"
          );
        },
        (error: any) => {
          this.toastrService.error("Falha ao recuperar Patrimonio", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public novoPatrimonio(): void {
    this.spinnerService.show();

    this.patrimonio = { ...this.formPatrimonio.value };

    this.patrimonio.status = true;
    this.patrimonio.dataAtualizacao = new Date().toISOString();
    this.patrimonio.dataCadastro = new Date().toISOString();

    console.log("Acervo update", this.acervo);

    if (this.acervo != null) this.patrimonio.acervoId = this.acervo.id;

    this.patrimonioService
      .createPatrimonio(this.patrimonio)
      .subscribe(
        (novoPatrimonio: Patrimonio) => {
          this.toastrService.success("Patrimonio cadastrado!", "Sucesso!");
          window.location.reload;
          this.router.navigateByUrl(
            `/patrimonios/detalhe/${novoPatrimonio.id}`
          );
        },
        (error: any) => {
          this.toastrService.error("Erro ao cadastrar Patrimônio", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public salvarPatrimonio(): void {
    this.spinnerService.show();

    this.patrimonio = {
      id: this.ctrF.patrimonioId.value,
      ...this.formPatrimonio.value,
    };
    this.patrimonio.dataCadastro = new Date().toISOString();
    console.log(this.patrimonio);
    this.patrimonioService
      .savePatrimonio(this.patrimonio)
      .subscribe(
        (patrimonio: Patrimonio) => {
          this.toastrService.success("Patrimônio Atualizado!", "Sucesso!");
        },
        (error: any) => {
          this.toastrService.error("Falha ao atualizar Patrimônio.", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
