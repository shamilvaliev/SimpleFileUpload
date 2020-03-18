import { Component, OnInit } from '@angular/core';
import { Group } from '../models/group';
import { UploadService } from '../upload.service';

@Component({
    selector: 'app-upload',
    templateUrl: './upload.component.html',
    styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

    fileGroups: Group[] = [];
    constructor(private uploadService: UploadService) {

    }

    getFiles(): void {
        this.uploadService.getFiles().subscribe(items => {
            this.fileGroups = items as Group[];
        });
    }
    ngOnInit() {
        this.getFiles();
    }

    onSuccessUploaded(success: boolean) {
        this.getFiles();
    }
}
