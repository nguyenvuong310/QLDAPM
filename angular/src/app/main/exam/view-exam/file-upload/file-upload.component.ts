import {Component, Injector, Input, OnInit} from '@angular/core';
import {FileUploader, FileUploaderOptions, FileItem} from 'ng2-file-upload';
import {AppComponentBase} from "@shared/common/app-component-base";
import {ProfileServiceProxy} from "@shared/service-proxies/service-proxies";
import {IAjaxResponse, TokenService} from "@node_modules/abp-ng2-module";
import {AppConsts} from "@shared/AppConsts";
import {appModuleAnimation} from "@shared/animations/routerTransition";

@Component({
    selector: 'file-upload-component',
    templateUrl: './file-upload.component.html',
    animations: [appModuleAnimation()]
})
export class FileUploadComponent extends AppComponentBase implements OnInit {
    public uploader: FileUploader;
    private _uploaderOptions: FileUploaderOptions = {};
    @Input() link!: string;
    @Input() id!: string;
    hasFileOver: boolean;

    constructor(
        injector: Injector,
        private _profileService: ProfileServiceProxy,
        private _tokenService: TokenService
    ) {
        super(injector);
    }

    ngOnInit() {
        this.initFileUploader();
    }

    initFileUploader(): void {
        this.uploader = new FileUploader({url: AppConsts.remoteServiceBaseUrl + this.link});
        this._uploaderOptions.autoUpload = false;
        this._uploaderOptions.authToken = 'Bearer ' + this._tokenService.getToken();
        this._uploaderOptions.removeAfterUpload = true;
        this.uploader.onAfterAddingFile = (file) => {
            file.withCredentials = false;
        };

        this.uploader.onBuildItemForm = (fileItem: FileItem, form: any) => {
            form.append('Id', this.id);
        };

        this.uploader.onSuccessItem = (item, response, status) => {
            const resp = <IAjaxResponse>JSON.parse(response);
            if (resp.success) {
                this.message.success(this.l("FileSavedSuccessfully", resp.result));
            } else {
                this.message.error(resp.error.message);
            }
        };

        this.uploader.setOptions(this._uploaderOptions);
        this.hasFileOver = false;
    }

    fileOver(e:any): void {
        this.hasFileOver = e;
    }
  

    save(): void {
        this.uploader.uploadAll();
    }
}