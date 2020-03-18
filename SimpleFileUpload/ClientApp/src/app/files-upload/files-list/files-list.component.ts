import { Component, OnInit, Input } from '@angular/core';
import { FileInfo } from '../models/file-info';

@Component({
  selector: 'app-files-list',
  templateUrl: './files-list.component.html',
  styleUrls: ['./files-list.component.css']
})
export class FilesListComponent implements OnInit {
    @Input() files: FileInfo[] = [];
    displayedColumns: string[] = ['no', 'name', 'size', 'date', 'userName'];
  constructor() { }

  ngOnInit() {
  }

}
