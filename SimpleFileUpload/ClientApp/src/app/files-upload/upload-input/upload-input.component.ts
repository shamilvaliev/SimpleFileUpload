import { Component, ViewChild, Output, EventEmitter } from '@angular/core';
import { UploadService } from '../upload.service';
import { forkJoin } from 'rxjs';
import { FileUploadResult } from '../models/file-upload-result';

@Component({
    selector: 'app-upload-input',
    templateUrl: './upload-input.component.html',
    styleUrls: ['./upload-input.component.css']
})
export class UploadInputComponent {

    @Output() onSuccessUploaded = new EventEmitter();

    @ViewChild('file', { static: false }) file;

    public files: Set<File> = new Set();

    constructor(private uploadService: UploadService) { }

    progress;
    primaryButtonText = 'Upload';
    showCancelButton = true;
    uploading = false;
    uploadSuccessful = false;
    canUpload = false;

    onFilesAdded() {
        let files: { [key: string]: File } = this.file.nativeElement.files;
        for (let key in files) {
            if (!isNaN(parseInt(key))) {
                this.files.add(files[key]);
            }
        }

        this.canUpload = true;
    }

    addFiles() {
        this.file.nativeElement.click();
    }
    resetForm() {
        this.uploadSuccessful = false;
        this.canUpload = false;
        this.primaryButtonText = 'Upload';
        this.files.clear();
    }
    startUpload() {
        if (this.uploadSuccessful) {
            
            //this.resetForm();
            return;
        }

        this.uploading = true;

        this.progress = this.uploadService.upload(this.files, this.onCompleteUpload);
        console.log(this.progress);
        for (const key in this.progress) {
            this.progress[key].progress.subscribe(val => {
                console.log(val);
            }
            );
        }

        let allProgressObservables = [];
        for (let key in this.progress) {
            allProgressObservables.push(this.progress[key].progress);
        }

        this.primaryButtonText = 'Finish';

        forkJoin(allProgressObservables).subscribe(end => {
            this.uploadSuccessful = true;
            console.log(this.uploadService.lastResult);
            this.uploading = false;
            this.onSuccessUploaded.emit(true);
            this.resetForm();
        });
    }

    onCompleteUpload(result: FileUploadResult[]) {
        
    }
}
