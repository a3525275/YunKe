(function() {
    $("#ParentName").bsSuggest({
        allowNoKeyword: true,
        multiWord: true,
        showHeader: true,
        effectiveFieldsAlias: { Id: "主键", Name: "名称", Rank: "等级", CreateDateTime: "创建时间" },
        effectiveFields: ["Id", "Name", "Rank", "CreateDateTime"],
        getDataMethod: "url",
        url: "/Hospitals/GetListWithKeywords?keywords=",
        idField: "Id",
        keyField: "Name"
    }).on('onSetSelectValue', function(e, data) {
        $("#ParentId").val(data.id);
    }).on('onUnsetSelectValue', function() {
        $("#ParentId").val("");
    });
})();