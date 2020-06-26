$(document).ready(function () {
    "use strict";
    new ApexCharts(document.querySelector("#apex7"), {
        chart: {
            height: 350,
            type: "line",
            stacked: !1
        },
        stroke: {
            width: [0, 2, 4],
            curve: "smooth"
        },
        plotOptions: {
            bar: {
                columnWidth: "40%"
            }
        },
        colors: ["#6e00ff", "#36b37e", "#E14A84"],
        series: [{
            name: "Facebook",
            type: "column",
            data: [30, 11, 22, 27, 13, 22, 37, 21, 44, 22, 30]
        }, {
            name: "Vine",
            type: "area",
            data: [48, 55, 41, 67, 22, 43, 21, 41, 56, 27, 43]
        }, {
            name: "Dribbble",
            type: "line",
            data: [40, 25, 36, 30, 45, 35, 64, 52, 59, 36, 39]
        }],
        fill: {
            opacity: [.85, .25, 1],
            gradient: {
                inverseColors: !1,
                shade: "light",
                type: "vertical",
                opacityFrom: .85,
                opacityTo: .55,
                stops: [0, 100, 100, 100]
            }
        },
        labels: ["01/01/2003", "02/01/2003", "03/01/2003", "04/01/2003", "05/01/2003", "06/01/2003", "07/01/2003", "08/01/2003", "09/01/2003", "10/01/2003", "11/01/2003"],
        markers: {
            size: 0
        },
        xaxis: {
            type: "datetime"
        },
        yaxis: {
            min: 0
        },
        tooltip: {
            shared: !0,
            intersect: !1,
            y: {
                formatter: function (e) {
                    return void 0 !== e ? e.toFixed(0) + " views" : e
                }
            }
        },
        legend: {
            labels: {
                useSeriesColors: !0
            },
            markers: {
                customHTML: [function () {
                    return ""
                }, function () {
                    return ""
                }, function () {
                    return ""
                }]
            }
        }
    }).render();
    new ApexCharts(document.querySelector("#apex2"), {
        chart: {
            height: 400,
            type: "area"
        },
        dataLabels: {
            enabled: !1
        },
        stroke: {
            curve: "smooth"
        },
        colors: ["#6610f2", "#7ee5e5"],
        series: [{
            name: "Profit",
            data: [131, 240, 145, 251, 142, 109, 300]
        }, {
            name: "Sale",
            data: [77, 62, 90, 72, 84, 72, 81]
        }],
        xaxis: {
            type: "datetime",
            categories: ["2018-09-19T00:00:00", "2018-09-19T01:30:00", "2018-09-19T02:30:00", "2018-09-19T03:30:00", "2018-09-19T04:30:00", "2018-09-19T05:30:00", "2018-09-19T06:30:00"]
        },
        tooltip: {
            x: {
                format: "dd/MM/yy HH:mm"
            }
        }
    }).render();
    var e = {
        chart: {
            type: "area",
            height: 300,
            parentHeightOffset: 0,
            foreColor: "#999",
            stacked: !0,
            dropShadow: {
                enabled: !0,
                enabledSeries: [0],
                top: -2,
                left: 2,
                blur: 5,
                opacity: .06
            }
        },
        colors: ["#6610f2", "#7ee5e5"],
        stroke: {
            curve: "smooth",
            width: 3
        },
        dataLabels: {
            enabled: !1
        },
        series: [{
            name: "Bitcoin",
            data: function (e, t) {
                var a = [[40, 30, 20, 29, 32, 19, 25, 55, 12, 27, 19, 24, 13, 29, 17, 32, 27, 15], [8, 3, 8, 7, 22, 16, 23, 7, 11, 5, 12, 5, 10, 4, 15, 2, 6, 2]],
                    o = 0,
                    r = [],
                    s = new Date("11 Nov 2019").getTime();
                for (; o < t;) r.push([s, a[e][o]]), s += 864e5, o++;
                return r
            }(0, 18)
        }],
        markers: {
            size: 0,
            strokeColor: "#fff",
            strokeWidth: 3,
            strokeOpacity: 1,
            fillOpacity: 1,
            hover: {
                size: 6
            }
        },
        xaxis: {
            type: "datetime",
            axisBorder: {
                show: !1
            },
            axisTicks: {
                show: !1
            }
        },
        yaxis: {
            tickAmount: 4,
            min: 0,
            labels: {
                offsetX: 24,
                offsetY: -5
            },
            tooltip: {
                enabled: !0
            }
        },
        grid: {
            borderColor: "rgba(77, 138, 240, .1)",
            padding: {
                left: -5,
                right: 5,
                bottom: -15
            }
        },
        tooltip: {
            x: {
                format: "dd MMM yyyy"
            }
        },
        legend: {
            position: "top",
            horizontalAlign: "left"
        },
        fill: {
            type: "solid",
            fillOpacity: .7
        }
    };
    new ApexCharts(document.querySelector("#apexareachart"), e).render()
}), $(window).on("load", function () {
    var e = "#6e00ff",
        t = "#0168fa",
        a = "#ff5630",
        o = "#FDAC41",
        r = "#E2ECFF",
        s = "#ffeed9",
        i = "#828D99",
        l = {
            chart: {
                height: 40,
                width: 40,
                type: "radialBar"
            },
            grid: {
                show: !1,
                padding: {
                    left: -30,
                    right: -30,
                    top: 0
                }
            },
            series: [30],
            colors: [t],
            plotOptions: {
                radialBar: {
                    hollow: {
                        size: "30%"
                    },
                    dataLabels: {
                        showOn: "always",
                        name: {
                            show: !1
                        },
                        value: {
                            show: !1
                        }
                    }
                }
            },
            fill: {
                type: "gradient",
                gradient: {
                    shade: "light",
                    type: "horizontal",
                    gradientToColors: [t],
                    opacityFrom: 1,
                    opacityTo: .8,
                    stops: [0, 70, 100]
                }
            },
            stroke: {
                lineCap: "round"
            }
        };
    new ApexCharts(document.querySelector("#radial-success-chart"), l).render();
    var n = {
        chart: {
            height: 40,
            width: 40,
            type: "radialBar"
        },
        grid: {
            show: !1,
            padding: {
                left: -30,
                right: -30,
                top: 0
            }
        },
        series: [80],
        colors: [o],
        plotOptions: {
            radialBar: {
                hollow: {
                    size: "30%"
                },
                dataLabels: {
                    showOn: "always",
                    name: {
                        show: !1
                    },
                    value: {
                        show: !1
                    }
                }
            }
        },
        fill: {
            type: "gradient",
            gradient: {
                shade: "light",
                type: "horizontal",
                gradientToColors: [o],
                opacityFrom: 1,
                opacityTo: .8,
                stops: [0, 70, 100]
            }
        },
        stroke: {
            lineCap: "round"
        }
    };
    new ApexCharts(document.querySelector("#radial-warning-chart"), n).render();
    var d = {
        chart: {
            height: 40,
            width: 40,
            type: "radialBar"
        },
        grid: {
            show: !1,
            padding: {
                left: -30,
                right: -30,
                top: 0
            }
        },
        series: [50],
        colors: [a],
        plotOptions: {
            radialBar: {
                hollow: {
                    size: "30%"
                },
                dataLabels: {
                    showOn: "always",
                    name: {
                        show: !1
                    },
                    value: {
                        show: !1
                    }
                }
            }
        },
        fill: {
            type: "gradient",
            gradient: {
                shade: "light",
                type: "horizontal",
                gradientToColors: [a],
                opacityFrom: 1,
                opacityTo: .8,
                stops: [0, 70, 100]
            }
        },
        stroke: {
            lineCap: "round"
        }
    };
    new ApexCharts(document.querySelector("#radial-danger-chart"), d).render();
    var h = {
        chart: {
            height: 260,
            type: "bar",
            toolbar: {
                show: !1
            }
        },
        plotOptions: {
            bar: {
                horizontal: !1,
                columnWidth: "20%",
                endingShape: "rounded"
            }
        },
        legend: {
            horizontalAlign: "right",
            offsetY: -10,
            markers: {
                radius: 50,
                height: 8,
                width: 8
            }
        },
        dataLabels: {
            enabled: !1
        },
        colors: [e, r],
        fill: {
            type: "gradient",
            gradient: {
                shade: "light",
                type: "vertical",
                inverseColors: !0,
                opacityFrom: 1,
                opacityTo: 1,
                stops: [0, 70, 100]
            }
        },
        series: [{
            name: "2019",
            data: [80, 95, 150, 210, 140, 230, 300, 280, 130]
        }, {
            name: "2018",
            data: [50, 70, 130, 180, 90, 180, 270, 220, 110]
        }],
        xaxis: {
            categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep"],
            axisBorder: {
                show: !1
            },
            axisTicks: {
                show: !1
            },
            labels: {
                style: {
                    colors: i
                }
            }
        },
        yaxis: {
            min: 0,
            max: 300,
            tickAmount: 3,
            labels: {
                style: {
                    color: i
                }
            }
        },
        legend: {
            show: !1
        },
        tooltip: {
            y: {
                formatter: function (e) {
                    return "$ " + e + " thousands"
                }
            }
        }
    };
    new ApexCharts(document.querySelector("#apexChartD"), h).render();
    var p = {
        chart: {
            height: 300,
            type: "line",
            toolbar: {
                show: !1
            }
        },
        grid: {
            show: !1,
            padding: {
                bottom: -20
            }
        },
        colors: [t],
        dataLabels: {
            enabled: !1
        },
        stroke: {
            width: 3,
            curve: "smooth"
        },
        series: [{
            data: [70, 0, 60, 50, 90, 0, 40, 25, 80, 40, 45]
        }],
        xaxis: {
            show: !1,
            labels: {
                show: !1
            },
            axisBorder: {
                show: !1
            }
        },
        yaxis: {
            show: !1
        }
    };
    new ApexCharts(document.querySelector("#success-line-chart"), p).render();
    var c = {
        chart: {
            width: 120,
            type: "donut"
        },
        dataLabels: {
            enabled: !1
        },
        series: [80, 30, 60],
        labels: ["Social", "Email", "Search"],
        stroke: {
            width: 0,
            lineCap: "round"
        },
        colors: [e],
        plotOptions: {
            pie: {
                donut: {
                    size: "90%",
                    labels: {
                        show: !0,
                        name: {
                            show: !0,
                            fontSize: "14px",
                            colors: "#6e00ff",
                            offsetY: 20,
                            fontFamily: "IBM Plex Sans"
                        },
                        value: {
                            show: !0,
                            fontSize: "26px",
                            fontFamily: "Rubik",
                            color: "#475f7b",
                            offsetY: -20,
                            formatter: function (e) {
                                return e
                            }
                        },
                        total: {
                            show: !0,
                            label: "Impression",
                            color: i,
                            formatter: function (e) {
                                return e.globals.seriesTotals.reduce(function (e, t) {
                                    return e + t
                                }, 0)
                            }
                        }
                    }
                }
            }
        },
        legend: {
            show: !1
        }
    };
    new ApexCharts(document.querySelector("#donutChart"), c).render();
    var w = {
        chart: {
            height: 120,
            type: "line",
            toolbar: {
                show: !1
            },
            sparkline: {
                enabled: !0
            }
        },
        plotOptions: {
            bar: {
                columnWidth: "25%",
                endingShape: "rounded"
            },
            distributed: !0
        },
        colors: [e, o],
        series: [{
            name: "New Clients",
            data: [85, 170, 230, 210, 45, 55, 150, 180, 50, 150, 240, 140, 75, 35, 1300, 120]
        }, {
            name: "Retained Clients",
            data: [-100, -55, -40, -120, -70, -40, -60, -50, -70, -30, -60, -40, -50, -70, -40, -50]
        }],
        grid: {
            show: !1
        },
        legend: {
            show: !1
        },
        dataLabels: {
            enabled: !1
        },
        tooltip: {
            x: {
                show: !1
            }
        }
    };
    new ApexCharts(document.querySelector("#bar-negative-chart"), w).render();
    var u = {
        chart: {
            height: 40,
            type: "line",
            toolbar: {
                show: !1
            },
            sparkline: {
                enabled: !0
            }
        },
        grid: {
            show: !1,
            padding: {
                bottom: 5,
                top: 5,
                left: 10,
                right: 0
            }
        },
        colors: [e],
        dataLabels: {
            enabled: !1
        },
        stroke: {
            width: 3,
            curve: "smooth"
        },
        series: [{
            data: [50, 100, 0, 60, 20, 30]
        }],
        fill: {
            type: "gradient",
            gradient: {
                shade: "dark",
                type: "horizontal",
                gradientToColors: [e],
                opacityFrom: 0,
                opacityTo: .9,
                stops: [0, 30, 70, 100]
            }
        },
        xaxis: {
            show: !1,
            labels: {
                show: !1
            },
            axisBorder: {
                show: !1
            }
        },
        yaxis: {
            show: !1
        }
    };
    new ApexCharts(document.querySelector("#primary-line-chart"), u).render();
    var y = {
        chart: {
            height: 40,
            type: "line",
            toolbar: {
                show: !1
            },
            sparkline: {
                enabled: !0
            }
        },
        grid: {
            show: !1,
            padding: {
                bottom: 5,
                top: 5,
                left: 10,
                right: 0
            }
        },
        colors: [o],
        dataLabels: {
            enabled: !1
        },
        stroke: {
            width: 3,
            curve: "smooth"
        },
        series: [{
            data: [30, 60, 30, 80, 20, 70]
        }],
        fill: {
            type: "gradient",
            gradient: {
                shade: "dark",
                type: "horizontal",
                gradientToColors: [o],
                opacityFrom: 0,
                opacityTo: .9,
                stops: [0, 30, 70, 100]
            }
        },
        xaxis: {
            show: !1,
            labels: {
                show: !1
            },
            axisBorder: {
                show: !1
            }
        },
        yaxis: {
            show: !1
        }
    };
    new ApexCharts(document.querySelector("#warning-line-chart"), y).render();
    var g = {
        chart: {
            height: 40,
            width: 40,
            type: "radialBar",
            sparkline: {
                show: !0
            }
        },
        grid: {
            show: !1,
            padding: {
                left: -30,
                right: -30,
                top: 0,
                bottom: -70
            }
        },
        series: [50],
        colors: [e],
        plotOptions: {
            radialBar: {
                hollow: {
                    size: "30%"
                },
                dataLabels: {
                    showOn: "always",
                    name: {
                        show: !1
                    },
                    value: {
                        show: !1
                    }
                }
            }
        },
        stroke: {
            lineCap: "round"
        }
    };
    new ApexCharts(document.querySelector("#profit-primary-chart"), g).render();
    var m = {
        chart: {
            height: 40,
            width: 40,
            type: "radialBar",
            sparkline: {
                show: !0
            }
        },
        grid: {
            show: !1,
            padding: {
                left: -30,
                right: -30,
                top: 0,
                bottom: -70
            }
        },
        series: [70],
        colors: ["#00CFDD"],
        plotOptions: {
            radialBar: {
                hollow: {
                    size: "30%"
                },
                dataLabels: {
                    showOn: "always",
                    name: {
                        show: !1
                    },
                    value: {
                        show: !1
                    }
                }
            }
        },
        stroke: {
            lineCap: "round"
        }
    };
    new ApexCharts(document.querySelector("#profit-info-chart"), m).render();
    var f = {
        chart: {
            type: "bar",
            height: 60,
            width: 120,
            sparkline: {
                enabled: !0
            },
            toolbar: {
                show: !1
            }
        },
        states: {
            hover: {
                filter: "none"
            }
        },
        colors: [s, s, s, s, o, s],
        series: [{
            name: "Sessions",
            data: [3, 7, 5, 15, 9, 8, 12]
        }],
        grid: {
            show: !1,
            padding: {
                left: 0,
                right: 0
            }
        },
        plotOptions: {
            bar: {
                columnWidth: "80%",
                distributed: !0
            }
        },
        tooltip: {
            x: {
                show: !1
            }
        },
        xaxis: {
            type: "numeric"
        }
    };
    new ApexCharts(document.querySelector("#registration-chart"), f).render();
    var b = {
        chart: {
            height: 100,
            type: "bar",
            stacked: !0,
            toolbar: {
                show: !1
            }
        },
        grid: {
            show: !1,
            padding: {
                left: 0,
                right: 0,
                top: -20,
                bottom: -15
            }
        },
        plotOptions: {
            bar: {
                horizontal: !1,
                columnWidth: "20%",
                endingShape: "rounded"
            }
        },
        legend: {
            show: !1
        },
        dataLabels: {
            enabled: !1
        },
        colors: [e, r],
        series: [{
            name: "2019",
            data: [80, 40, 30, 90, 20, 50, 95]
        }, {
            name: "2018",
            data: [20, 60, 70, 10, 80, 50, 5]
        }],
        xaxis: {
            categories: ["S", "M", "T", "W", "T", "F", "S"],
            axisBorder: {
                show: !1
            },
            axisTicks: {
                show: !1
            },
            labels: {
                style: {
                    colors: i
                },
                offsetY: -5
            }
        },
        yaxis: {
            show: !1,
            floating: !0
        },
        tooltip: {
            x: {
                show: !1
            }
        }
    };
    new ApexCharts(document.querySelector("#salesChart"), b).render()
});