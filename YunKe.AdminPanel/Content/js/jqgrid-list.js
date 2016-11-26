
var formatters = {
    gender: function (cellValue, options, rowObject) {
        console.log(cellValue);
        return cellValue == "1" ? "男" : (cellValue == "0" ? "未知" : "女");
    },
    sourceType : function (cellValue, options, rowObject) {
        var result = rowObject.SourceType;
        switch (result) {
            case 0:
            default:
                result = "普通号";
                break;
            case 1:
                result = "专家";
                break;
            case 2:
                result = "专家和特需";
                break;
            case 3:
                result = "特需";
                break;
        }

        return result;
    },
    appointStatus: function (cellValue, options, rowObject) {
        var result = rowObject.Status;
        switch (result) {
            case 0:
            case 1:
            default:
                result = "登记";
                break;
            case 2:
                result = "已取消";
                break;
            case 3:
                result = "已就诊";
                break;
        }

        return result;
    }
};


var JucheapGrid = {
    Load: function (config) {
        var jqGrid = !config.id ? $("#table_list") : $("#" + config.id);
        jqGrid.jqGrid({
            caption: config.title,
            url: config.url,
            mtype: "GET",
            styleUI: 'Bootstrap',
            datatype: "json",
            colNames: config.colNames,
            colModel: config.colModel,
            viewrecords: true,
            multiselect: true,
            rownumbers: true,
            autowidth: true,
            height: "100%",
            rowNum: config.rows || 15,
            rownumWidth: 35,
            emptyrecords: "没有相关数据",
            loadComplete: function (xhr) {
                if (xhr && xhr.code === 401) {
                    alert(xhr.msg);
                }
            },
            // enable tree grid
            "treeGrid": config.treeGrid || false,
            // which column is expandable
            "ExpandColumn": config.expandColumn || "id",
            // expand a node when click on the node name 
            "ExpandColClick": true,
            //"loadonce": true,
            // datatype
            "treedatatype": "json",
            // the model used
            "treeGridModel": "adjacency",
            // configuration of the data comming from server
            "treeReader": {
                "parent_id_field": "ParentId",
                "level_field": "level",
                "leaf_field": "isLeaf",
                "expanded_field": "expanded",
                "loaded": "loaded"
            },
            // set the tree icons
            "treeIcons": {
                //"plus": "glyphicon-plus",
                //"minus": "glyphicon-minus",
                "leaf": ""
            },
            loadError: function (xhr, status, error) { console.log(xhr); console.log(status); console.log(error); },
            pager: !config.pagerId ? "#pager_list" : "#" + config.pagerId,
            subGrid: config.subGrid ? true : false,
            subGridRowExpanded: config.subGridRowExpanded ? config.subGridRowExpanded : null,
            gridComplete: config.gridComplete ? config.gridComplete : function () { }
        });

        // Add responsive to jqGrid
        $(window).bind('resize', function () {
            var width = $('.jqGrid_wrapper').width();
            jqGrid.setGridWidth(width);
        });

        $(document).on("click", ".delete-inline", function () {
            var url = $(this).attr("href");
            var ids = $(this).data("oid");

            XPage.DelData(url, ids);
            return false;
        });
    },
    //获取jqgrid的编辑内容
    GetData: function () {
        var id = $('#table_list').jqGrid('getGridParam', 'selrow');
        if (id)
            return $('#table_list').jqGrid("getRowData", id);
        else
            return null;
    },
    //获取jqgrid要删除的内容
    GetDataTableDeleteData: function () {
        return JucheapGrid.GetAllSelected("table_list");
    },
    //获取所有选择项
    GetAllSelected: function (id) {
        var res = {
            Len: 0,
            Data: []
        };
        var grid = $("#" + id);
        var rowKey = grid.getGridParam("selrow");

        if (rowKey) {
            var selectedIDs = grid.getGridParam("selarrrow");
            for (var i = 0; i < selectedIDs.length; i++) {
                res.Data.push(selectedIDs[i]);
            }
        }
        res.Len = res.Data.length;
        return res;
    }
};

