import { Injectable } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Injectable({ providedIn: 'root' })
export class ImageService {

  constructor(private sanitizer: DomSanitizer) { }

  getGif(gif: any): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl('data:image/gif;base64,' + gif);
  }

  getJpeg(jpeg: any): SafeUrl {
    return this.sanitizer.bypassSecurityTrustUrl('data:image/jpeg;base64,' + jpeg);
  }
}
