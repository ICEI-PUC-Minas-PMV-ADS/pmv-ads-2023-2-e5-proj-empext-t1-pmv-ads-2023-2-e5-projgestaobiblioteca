import { Component, Inject, OnInit} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { EmprestimoService } from 'src/app/services';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-modal-renovar',
  templateUrl: './modalRenovar.component.html',
  styleUrls: ['./modalRenovar.component.scss']
})
export class ModalRenovarComponent implements OnInit {
  title = 'angular-material';

  public emprestimoParam: any = "";

  constructor(@Inject(MAT_DIALOG_DATA) public dataInput: { emprestimoId: number}, 
  private router: Router,
  private emprestimoService: EmprestimoService,
  private spinnerService: NgxSpinnerService,
  private toastrService: ToastrService,
  private dialog: MatDialog) {  }

  ngOnInit(): void {
    this.emprestimoParam = this.dataInput.emprestimoId;
  }
  
  voltar() {
    this.router.navigate(['/acervos/detalhe']); 
}

public renovarEmprestimo(): void {
  this.spinnerService.show();

  this.emprestimoService.renovarEmprestimo(this.emprestimoParam).subscribe(
    () => {
      this.voltar()
    },
    (error: any) => {
      this.toastrService.error("Ocorreu um erro ao tentar renovar o empréstimo");
      console.error(error)
    }
  )
    .add(() => this.spinnerService.hide())
}

}