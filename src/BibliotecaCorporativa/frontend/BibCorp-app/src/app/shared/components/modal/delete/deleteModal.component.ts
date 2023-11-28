import { Component, Inject, OnInit } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ModalDelete } from "src/app/shared/models";

@Component({
  selector: "app-deleteModal",
  templateUrl: "./deleteModal.component.html",
  styleUrls: ["./deleteModal.component.scss"],
})
export class DeleteModalComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ModalDelete
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
