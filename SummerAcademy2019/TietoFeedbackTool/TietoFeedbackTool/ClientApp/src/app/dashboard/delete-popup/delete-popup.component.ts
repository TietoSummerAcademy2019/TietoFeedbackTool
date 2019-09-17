import { Component, OnInit, Input, Inject } from '@angular/core';
import { DisplayDataService } from 'src/app/display-data/display-data.service';
import { Account } from '../../models/Account';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';


@Component({
  selector: 'app-delete-popup',
  templateUrl: './delete-popup.component.html',
  styleUrls: ['./delete-popup.component.scss']
})
export class DeletePopupComponent {

  constructor(
    private ds: DisplayDataService<Account>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<DeletePopupComponent>
  ) { }

  removeQuestion() {
    console.log(this.data.idQ);
    this.ds.remove(this.data.idQ)
  }

  closeDialog() {
    this.dialogRef.close();
  }
}