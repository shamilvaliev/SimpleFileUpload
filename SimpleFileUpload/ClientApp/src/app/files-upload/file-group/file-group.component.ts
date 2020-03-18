import { Component, OnInit, Input } from '@angular/core';
import { Group } from '../models/group';

@Component({
  selector: 'app-file-group',
  templateUrl: './file-group.component.html',
  styleUrls: ['./file-group.component.css']
})
export class FileGroupComponent implements OnInit {
    @Input() fileGroup: Group;
  constructor() { }

  ngOnInit() {
  }

}
