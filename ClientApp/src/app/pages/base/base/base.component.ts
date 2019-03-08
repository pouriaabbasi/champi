import { Component, OnInit, Renderer2, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent implements OnInit {

  constructor(
    protected renderer2: Renderer2,
    @Inject(DOCUMENT) protected document,
  ) { }

  ngOnInit() {
  }

  protected SetDataTable(tableId: string) {
    setTimeout(() => {
      const script = this.renderer2.createElement('script');
      script.text = `
      $(document).ready(function () {
        $('#${tableId}').dataTable({
          "language": {
            "search": "جستجو:",
            "emptyTable": "اطلاعاتی برای نمایش موجود نیست",
            "info": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
            "infoEmpty": "اطلاعاتی برای نمایش موجود نیست",
            "infoFiltered": "(فیلتر شده از _MAX_ رکورد)",
            "zeroRecords": "اطلاعاتی برای نمایش وجود ندارد",
            "lengthMenu": "نمایش _MENU_ رکورد",
            "paginate": {
              "first": "اولین",
              "last": "آخرین",
              "next": "بعدی",
              "previous": "قبلی"
            },
          }
        });
      });
    `;

      this.renderer2.appendChild(this.document.body, script);
    }, 50);
  }

}
