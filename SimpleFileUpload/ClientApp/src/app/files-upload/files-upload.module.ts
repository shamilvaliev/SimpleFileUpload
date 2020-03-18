import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UploadComponent } from './upload/upload.component';

import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule, MatListModule, MatProgressBarModule, MatTableModule } from '@angular/material';

import { FilesListComponent } from './files-list/files-list.component';
import { UploadInputComponent } from './upload-input/upload-input.component';
import { FileGroupComponent } from './file-group/file-group.component';

import { Group } from './models/group';
import { FileInfo } from './models/file-info';

@NgModule({
    declarations: [UploadComponent,
        FilesListComponent,
        UploadInputComponent,
        FileGroupComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        MatButtonModule, MatListModule, MatProgressBarModule,
        MatTableModule
    ],
    exports: [
        UploadComponent
    ]
})
export class FilesUploadModule { }
