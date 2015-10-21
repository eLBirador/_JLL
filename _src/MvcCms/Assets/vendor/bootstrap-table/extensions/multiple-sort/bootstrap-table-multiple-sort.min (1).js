/*
* bootstrap-table - v1.8.1 - 2015-05-29
* https://github.com/wenzhixin/bootstrap-table
* Copyright (c) 2015 zhixin wen
* Licensed MIT License
*/
!function(a){"use strict";var b=!1,c={asc:"Ascending",desc:"Descending"},d="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAATCAYAAAByUDbMAAAAZ0lEQVQ4y2NgGLKgquEuFxBPAGI2ahhWCsS/gDibUoO0gPgxEP8H4ttArEyuQYxAPBdqEAxPBImTY5gjEL9DM+wTENuQahAvEO9DMwiGdwAxOymGJQLxTyD+jgWDxCMZRsEoGAVoAADeemwtPcZI2wAAAABJRU5ErkJggg==",e="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAATCAYAAAByUDbMAAAAZUlEQVQ4y2NgGAWjYBSggaqGu5FA/BOIv2PBIPFEUgxjB+IdQPwfC94HxLykus4GiD+hGfQOiB3J8SojEE9EM2wuSJzcsFMG4ttQgx4DsRalkZENxL+AuJQaMcsGxBOAmGvopk8AVz1sLZgg0bsAAAAASUVORK5CYII= ",f=function(b){if(!a("#sortModal").hasClass("modal")){var c='  <div class="modal fade" id="sortModal" tabindex="-1" role="dialog" aria-labelledby="sortModalLabel" aria-hidden="true">';c+='         <div class="modal-dialog">',c+='             <div class="modal-content">',c+='                 <div class="modal-header">',c+='                     <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>',c+='                     <h4 class="modal-title" id="sortModalLabel">'+b.options.formatMultipleSort()+"</h4>",c+="                 </div>",c+='                 <div class="modal-body">',c+='                     <div class="bootstrap-table">',c+='                         <div class="fixed-table-toolbar">',c+='                             <div class="bars">',c+='                                 <div id="toolbar">',c+='                                     <button id="add" type="button" class="btn btn-default"><i class="'+b.options.iconsPrefix+" "+b.options.icons.plus+'"></i> '+b.options.formatAddLevel()+"</button>",c+='                                     <button id="delete" type="button" class="btn btn-default" disabled><i class="'+b.options.iconsPrefix+" "+b.options.icons.minus+'"></i> '+b.options.formatDeleteLevel()+"</button>",c+="                                 </div>",c+="                             </div>",c+="                         </div>",c+='                         <div class="fixed-table-container">',c+='                             <table id="multi-sort" class="table">',c+="                                 <thead>",c+="                                     <tr>",c+="                                         <th></th>",c+='                                         <th><div class="th-inner">'+b.options.formatColumn()+"</div></th>",c+='                                         <th><div class="th-inner">'+b.options.formatOrder()+"</div></th>",c+="                                     </tr>",c+="                                 </thead>",c+="                                 <tbody></tbody>",c+="                             </table>",c+="                         </div>",c+="                     </div>",c+="                 </div>",c+='                 <div class="modal-footer">',c+='                     <button type="button" class="btn btn-default" data-dismiss="modal">'+b.options.formatCancel()+"</button>",c+='                     <button type="button" class="btn btn-primary">'+b.options.formatSort()+"</button>",c+="                 </div>",c+="             </div>",c+="         </div>",c+="     </div>",a("body").append(a(c));var d=a("#sortModal"),e=d.find("tbody > tr");if(d.off("click","#add").on("click","#add",function(){var a=d.find(".multi-sort-name:first option").length,c=d.find("tbody tr").length;a>c&&(c++,b.addLevel(),b.setButtonStates())}),d.off("click","#delete").on("click","#delete",function(){var a=d.find(".multi-sort-name:first option").length,c=d.find("tbody tr").length;c>1&&a>=c&&(c--,d.find("tbody tr:last").remove(),b.setButtonStates())}),d.off("click",".btn-primary").on("click",".btn-primary",function(){var c=d.find("tbody > tr"),e=d.find("div.alert"),f=[],g=[];b.options.sortPriority=a.map(c,function(b){var c=a(b),d=c.find(".multi-sort-name").val(),e=c.find(".multi-sort-order").val();return f.push(d),{sortName:d,sortOrder:e}});for(var h=f.sort(),i=0;i<f.length-1;i++)h[i+1]==h[i]&&g.push(h[i]);g.length>0?0===e.length&&(e='<div class="alert alert-danger" role="alert"><strong>'+b.options.formatDuplicateAlertTitle()+"</strong> "+b.options.formatDuplicateAlertDescription()+"</div>",a(e).insertBefore(d.find(".bars"))):(1===e.length&&a(e).remove(),b.options.sortName="",b.onMultipleSort(),d.modal("hide"))}),null===b.options.sortPriority&&b.options.sortName&&(b.options.sortPriority=[{sortName:b.options.sortName,sortOrder:b.options.sortOrder}]),null!==b.options.sortPriority){if(e.length<b.options.sortPriority.length&&"object"==typeof b.options.sortPriority)for(var f=0;f<b.options.sortPriority.length;f++)b.addLevel(f,b.options.sortPriority[f])}else b.addLevel(0);b.setButtonStates()}};a.extend(a.fn.bootstrapTable.defaults,{showMultiSort:!1,sortPriority:null,onMultipleSort:function(){return!1}}),a.extend(a.fn.bootstrapTable.defaults.icons,{sort:"glyphicon-sort",plus:"glyphicon-plus",minus:"glyphicon-minus"}),a.extend(a.fn.bootstrapTable.Constructor.EVENTS,{"multiple-sort.bs.table":"onMultipleSort"}),a.extend(a.fn.bootstrapTable.locales,{formatMultipleSort:function(){return"Multiple Sort"},formatAddLevel:function(){return"Add Level"},formatDeleteLevel:function(){return"Delete Level"},formatColumn:function(){return"Column"},formatOrder:function(){return"Order"},formatSortBy:function(){return"Sort by"},formatThenBy:function(){return"Then by"},formatSort:function(){return"Sort"},formatCancel:function(){return"Cancel"},formatDuplicateAlertTitle:function(){return"Duplicate(s) detected!"},formatDuplicateAlertDescription:function(){return"Please remove or change any duplicate column."}}),a.extend(a.fn.bootstrapTable.defaults,a.fn.bootstrapTable.locales);var g=a.fn.bootstrapTable.Constructor,h=g.prototype.initToolbar;g.prototype.initToolbar=function(){this.showToolbar=!0;var c=this;if(h.apply(this,Array.prototype.slice.apply(arguments)),this.options.showMultiSort){var d=this.$toolbar.find(">.btn-group"),e=d.find("div.multi-sort");e.length||(e='  <button class="multi-sort btn btn-default'+(void 0===this.options.iconSize?"":" btn-"+this.options.iconSize)+'" type="button" data-toggle="modal" data-target="#sortModal" title="'+this.options.formatMultipleSort()+'">',e+='     <i class="'+this.options.iconsPrefix+" "+this.options.icons.sort+'"></i>',e+="</button>",d.append(e),f(c)),this.$el.one("sort.bs.table",function(){b=!0}),this.$el.on("multiple-sort.bs.table",function(){b=!1}),this.$el.on("load-success.bs.table",function(){b||null===c.options.sortPriority||"object"!=typeof c.options.sortPriority||c.onMultipleSort()}),this.$el.on("column-switch.bs.table",function(){c.options.sortPriority=null,a("#sortModal").remove(),f(c)})}},g.prototype.onMultipleSort=function(){var b=this,c=function(a,b){return a>b?1:b>a?-1:0},d=function(d,e){for(var f=[],g=[],h=0;h<b.options.sortPriority.length;h++){var i="desc"===b.options.sortPriority[h].sortOrder?-1:1,j=d[b.options.sortPriority[h].sortName],k=e[b.options.sortPriority[h].sortName];(void 0===j||null===j)&&(j=""),(void 0===k||null===k)&&(k=""),a.isNumeric(j)&&a.isNumeric(k)&&(j=parseFloat(j),k=parseFloat(k)),"string"!=typeof j&&(j=j.toString()),f.push(i*c(j,k)),g.push(i*c(k,j))}return c(f,g)};this.data.sort(function(a,b){return d(a,b)}),this.initBody(),this.assignSortableArrows(),this.trigger("multiple-sort")},g.prototype.addLevel=function(b,d){var e=a("#sortModal"),f=0===b?this.options.formatSortBy():this.options.formatThenBy();e.find("tbody").append(a("<tr>").append(a("<td>").text(f)).append(a("<td>").append(a('<select class="form-control multi-sort-name">'))).append(a("<td>").append(a('<select class="form-control multi-sort-order">'))));var g=e.find(".multi-sort-name").last(),h=e.find(".multi-sort-order").last();this.options.columns.forEach(function(a){return a.sortable===!1||a.visible===!1?!0:void g.append('<option value="'+a.field+'">'+a.title+"</option>")}),a.each(c,function(a,b){h.append('<option value="'+a+'">'+b+"</option>")}),void 0!==d&&(g.find('option[value="'+d.sortName+'"]').attr("selected",!0),h.find('option[value="'+d.sortOrder+'"]').attr("selected",!0))},g.prototype.assignSortableArrows=function(){for(var b=this,c=b.$header.find("th"),f=0;f<c.length;f++)for(var g=0;g<b.options.sortPriority.length;g++)a(c[f]).data("field")===b.options.sortPriority[g].sortName&&a(c[f]).find(".sortable").css("background-image","url("+("desc"===b.options.sortPriority[g].sortOrder?e:d)+")")},g.prototype.setButtonStates=function(){var b=a("#sortModal"),c=b.find(".multi-sort-name:first option").length,d=b.find("tbody tr").length;d==c&&b.find("#add").attr("disabled","disabled"),d>1&&b.find("#delete").removeAttr("disabled"),c>d&&b.find("#add").removeAttr("disabled"),1==d&&b.find("#delete").attr("disabled","disabled")}}(jQuery);