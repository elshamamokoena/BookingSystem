(function () {
    window.navigationManager = {

        navigationManagerInit: function navigationManagerInit(navigationmanageObject) {

            navigationManagerObject = navigationmanageObject; 
        },

        navigateTo: function navigateTo(url) {
            navigationManagerObject.invokeMethodAsync('NavigateTo', url);
        },


    }

    window.oneModuleToRuleThemAll = {
        // ****************************      exports       ********************************

//        utilsInit: function utilsInit() {
//            var docReady = function docReady(fn) {
//            // see if DOM is already available
//            if (document.readyState === 'loading') {
//                document.addEventListener('DOMContentLoaded', fn);
//            } else {
//                setTimeout(fn, 1);
//            }
//            };

//            var resize= function resize(fn) {
//                return window.addEventListener('resize', fn);
//            };

//            var isIterableArray = function isIterableArray(array) {
//                return Array.isArray(array) && !!array.length;
//            };

//            var camelize = function camelize(str) {
//                var text = str.replace(/[-_\s.]+(.)?/g, function (_, c) {
//                    return c ? c.toUpperCase() : '';
//                });
//                return "".concat(text.substr(0, 1).toLowerCase()).concat(text.substr(1));
//            };

//            var getData = function getData(el, data) {
//                try {
//                    return JSON.parse(el.dataset[camelize(data)]);
//                } catch (e) {
//                    return el.dataset[camelize(data)];
//                }
//            };

//},

        swiperInit: function swiperInit() {

            var swipers = document.querySelectorAll('[data-swiper]');
            var navbarVerticalToggle = document.querySelector('.navbar-vertical-toggle');
            swipers.forEach(function (swiper) {
            var options = utils.getData(swiper, 'swiper');
            var thumbsOptions = options.thumb;
            var thumbsInit;

            if (thumbsOptions) {
                var thumbImages = swiper.querySelectorAll('img');
                var slides = '';
                thumbImages.forEach(function (img) {
                    slides += "\n          <div class='swiper-slide '>\n            <img class='img-fluid rounded mt-1' src=".concat(img.src, " alt=''/>\n          </div>\n        ");
                });
                var thumbs = document.createElement('div');
                thumbs.setAttribute('class', 'swiper-container thumb');
                thumbs.innerHTML = "<div class='swiper-wrapper'>".concat(slides, "</div>");

                if (thumbsOptions.parent) {
                    var parent = document.querySelector(thumbsOptions.parent);
                    parent.parentNode.appendChild(thumbs);
                } else {
                    swiper.parentNode.appendChild(thumbs);
                }

                thumbsInit = new window.Swiper(thumbs, thumbsOptions);
            }

            var swiperNav = swiper.querySelector('.swiper-nav');
            var newSwiper = new window.Swiper(swiper, _objectSpread(_objectSpread({}, options), {}, {
                navigation: {
                    nextEl: swiperNav === null || swiperNav === void 0 ? void 0 : swiperNav.querySelector('.swiper-button-next'),
                    prevEl: swiperNav === null || swiperNav === void 0 ? void 0 : swiperNav.querySelector('.swiper-button-prev')
                },
                thumbs: {
                    swiper: thumbsInit
                }
            }));

            if (navbarVerticalToggle) {
                navbarVerticalToggle.addEventListener('navbar.vertical.toggle', function () {
                    newSwiper.update();
                });
                }
            });
        },
        handleNavbarVerticalCollapsed: function handleNavbarVerticalCollapsed() {
            var Selector = {
                HTML: 'html',
                NAVBAR_VERTICAL_TOGGLE: '.navbar-vertical-toggle',
                NAVBAR_VERTICAL_COLLAPSE: '.navbar-vertical .navbar-collapse',
                ECHART_RESPONSIVE: '[data-echart-responsive]'
            };
            var Events = {
                CLICK: 'click',
                MOUSE_OVER: 'mouseover',
                MOUSE_LEAVE: 'mouseleave',
                NAVBAR_VERTICAL_TOGGLE: 'navbar.vertical.toggle'
            };
            var ClassNames = {
                NAVBAR_VERTICAL_COLLAPSED: 'navbar-vertical-collapsed',
                NAVBAR_VERTICAL_COLLAPSED_HOVER: 'navbar-vertical-collapsed-hover'
            };
            var navbarVerticalToggle = document.querySelector(Selector.NAVBAR_VERTICAL_TOGGLE);
            var html = document.querySelector(Selector.HTML);
            var navbarVerticalCollapse = document.querySelector(Selector.NAVBAR_VERTICAL_COLLAPSE);

            if (navbarVerticalToggle) {
                navbarVerticalToggle.addEventListener(Events.CLICK, function (e) {
                    navbarVerticalToggle.blur();
                    html.classList.toggle(ClassNames.NAVBAR_VERTICAL_COLLAPSED); // Set collapse state on localStorage

                    var isNavbarVerticalCollapsed = utils.getItemFromStore('isNavbarVerticalCollapsed');
                    utils.setItemToStore('isNavbarVerticalCollapsed', !isNavbarVerticalCollapsed);
                    var event = new CustomEvent(Events.NAVBAR_VERTICAL_TOGGLE);
                    e.currentTarget.dispatchEvent(event);
                });
            }

            if (navbarVerticalCollapse) {
                navbarVerticalCollapse.addEventListener(Events.MOUSE_OVER, function () {
                    if (utils.hasClass(html, ClassNames.NAVBAR_VERTICAL_COLLAPSED)) {
                        html.classList.add(ClassNames.NAVBAR_VERTICAL_COLLAPSED_HOVER);
                    }
                });
                navbarVerticalCollapse.addEventListener(Events.MOUSE_LEAVE, function () {
                    if (utils.hasClass(html, ClassNames.NAVBAR_VERTICAL_COLLAPSED_HOVER)) {
                        html.classList.remove(ClassNames.NAVBAR_VERTICAL_COLLAPSED_HOVER);
                    }
                });
            }
        },
        select2Init : function select2Init() {
            if (window.jQuery) {
                var $ = window.jQuery;
                var select2 = $('.selectpicker');
                select2.length && select2.each(function (index, value) {
                    var $this = $(value);
                    var options = $.extend({
                        theme: 'bootstrap-5'
                    }, $this.data('options'));
                    $this.select2(options);
                });
            }
        },
        choicesInit: function choicesInit() {
            if (window.Choices) {
                var elements = document.querySelectorAll('.js-choice');
                elements.forEach(function (item) {
                    var userOptions = utils.getData(item, 'options');
                    var choices = new window.Choices(item, _objectSpread({
                        itemSelectText: ''
                    }, userOptions));
                    var needsValidation = document.querySelectorAll('.needs-validation');
                    needsValidation.forEach(function (validationItem) {
                        var selectFormValidation = function selectFormValidation() {
                            validationItem.querySelectorAll('.choices').forEach(function (choicesItem) {
                                var singleSelect = choicesItem.querySelector('.choices__list--single');
                                var multipleSelect = choicesItem.querySelector('.choices__list--multiple');

                                if (choicesItem.querySelector('[required]')) {
                                    if (singleSelect) {
                                        var _singleSelect$querySe;

                                        if (((_singleSelect$querySe = singleSelect.querySelector('.choices__item--selectable')) === null || _singleSelect$querySe === void 0 ? void 0 : _singleSelect$querySe.getAttribute('data-value')) !== '') {
                                            choicesItem.classList.remove('invalid');
                                            choicesItem.classList.add('valid');
                                        } else {
                                            choicesItem.classList.remove('valid');
                                            choicesItem.classList.add('invalid');
                                        }
                                    } //----- for multiple select only ----------

                                    console.log(choicesItem.getElementsByTagName('option').length.value);

                                    if (multipleSelect) {
                                        if (choicesItem.getElementsByTagName('option').length) {
                                            choicesItem.classList.remove('invalid');
                                            choicesItem.classList.add('valid');
                                        } else {
                                            choicesItem.classList.remove('valid');
                                            choicesItem.classList.add('invalid');
                                        }
                                    } //------ select end ---------------

                                }
                            });
                        };

                        validationItem.addEventListener('submit', function () {
                            selectFormValidation();
                        });
                        item.addEventListener('change', function () {
                            selectFormValidation();
                        });
                    });
                    return choices;
                });
            }
        },
        advanceAjaxTableInit: function advanceAjaxTableInit(bookingsfromdb, navigationManager) {

            const bookings = [...bookingsfromdb];

            const togglePaginationButtonDisable = (button, disabled) => {
                const updatedButton = button;
                updatedButton.disabled = disabled;
                updatedButton.classList[disabled ? 'add' : 'remove']('disabled');
            };
            // Selectors
            const table = document.getElementById('bookingListTable');

            if (table) {
                const options = {
                    page: 5,
                    pagination: {
                        item: "<li><button class='page' type='button'></button></li>"
                    },
                    item: values => {
                        const {bookingNumber, employee, created, event, status, badge, conferenceRoom } =
                            values;

                        return `
                      <tr class="btn-reveal-trigger">
                        <td class="order py-2 align-middle white-space-nowrap">
                          <a href="https://prium.github.io/falcon/v3.16.0/app/e-commerce/orders/order-details.html">
                            <strong>#${bookingNumber}</strong>
                          </a>
                          by
                          <strong>${employee.name}</strong>
                          <br />
                          <a href="mailto:${employee.email}">${employee.email}</a>
                        </td>
                        <td class="py-2 align-middle">
                          ${created}
                        </td>
                        <td class="py-2 align-middle white-space-nowrap">
                          ${event.title}
                          <p class="mb-0 text-500">${event.title}</p>
                        </td>
                        <td class="py-2 align-middle text-center fs-9 white-space-nowrap">
                          <span class="badge rounded-pill d-block bg-soft-${badge.type}">
                            ${status}
                            <span class="ms-1 ${badge.icon}" data-fa-transform="shrink-2"></span>
                          </span>
                        </td>
                        <td class="py-2 align-middle text-end fs-9 fw-medium">
                          ${conferenceRoom.name}
                        </td>
                        <td class="py-2 align-middle white-space-nowrap text-end">
                          <div class="dropstart font-sans-serif position-static d-inline-block">
                            <button class="btn btn-link text-600 btn-sm dropdown-toggle btn-reveal" type='button' id="booking-dropdown-${bookingNumber}" data-bs-toggle="dropdown" data-boundary="window" aria-haspopup="true" aria-expanded="false" data-bs-reference="parent">
                              <span class="fas fa-ellipsis-h fs-10"></span>
                            </button>
                            <div class="dropdown-menu dropdown-menu-end border py-2" aria-labelledby="booking-dropdown-${bookingNumber}">
                              <a href="#!" class="dropdown-item">View</a>
                              <a href="#!" class="dropdown-item">Edit</a>
                              <a href="#!" class="dropdown-item">Refund</a>
                              <div class"dropdown-divider"></div>
                              <a href="#!" class="dropdown-item text-warning">Archive</a>
                              <a href="#!" class="dropdown-item text-warning">Archive</a>
                            </div>
                          </div>
                        </td>
                      </tr>
                    `;
                    }
                };


                const paginationButtonNext = table.querySelector('[data-list-pagination="next"]');
                const paginationButtonPrev = table.querySelector('[data-list-pagination="prev"]');
                const viewAll = table.querySelector('[data-list-view="*"]');
                const viewLess = table.querySelector('[data-list-view="less"]');
                const listInfo = table.querySelector('[data-list-info]');
                const listFilter = document.querySelector('[data-list-filter]');


                const bookingList = new window.List(table, options, bookings);

                // Fallback
                bookingList.on('updated', item => {
                    const fallback =
                        table.querySelector('.fallback') || document.getElementById(options.fallback);

                    if (fallback) {
                        if (item.matchingItems.length === 0) {
                            fallback.classList.remove('d-none');
                        } else {
                            fallback.classList.add('d-none');
                        }
                    }
                });

                const totalItem = bookingList.items.length;
                const itemsPerPage = bookingList.page;
                const btnDropdownClose = bookingList.listContainer.querySelector('.btn-close');
                let pageQuantity = Math.ceil(totalItem / itemsPerPage);
                let numberOfcurrentItems = bookingList.visibleItems.length;
                let pageCount = 1;

                btnDropdownClose &&
                    btnDropdownClose.addEventListener('search.close', () => bookingList.fuzzySearch(''));

                const updateListControls = () => {
                    listInfo &&
                        (listInfo.innerHTML = `${bookingList.i} to ${numberOfcurrentItems} of ${totalItem}`);
                    paginationButtonPrev && togglePaginationButtonDisable(paginationButtonPrev, pageCount === 1);
                    if (paginationButtonNext) {
                        togglePaginationButtonDisable(paginationButtonNext, pageCount === pageQuantity);
                    }

                    if (pageCount > 1 && pageCount < pageQuantity) {
                        togglePaginationButtonDisable(paginationButtonNext, false);
                        togglePaginationButtonDisable(paginationButtonPrev, false);
                    }
                };
                updateListControls();

                if (paginationButtonNext) {
                    paginationButtonNext.addEventListener('click', e => {
                        e.preventDefault();
                        pageCount += 1;

                        const nextInitialIndex = bookingList.i + itemsPerPage;
                        nextInitialIndex <= bookingList.size() && bookingList.show(nextInitialIndex, itemsPerPage);
                        numberOfcurrentItems += bookingList.visibleItems.length;
                        updateListControls();
                    });
                }

                if (paginationButtonPrev) {
                    paginationButtonPrev.addEventListener('click', e => {
                        e.preventDefault();
                        pageCount -= 1;

                        numberOfcurrentItems -= bookingList.visibleItems.length;
                        const prevItem = bookingList.i - itemsPerPage;
                        prevItem > 0 && bookingList.show(prevItem, itemsPerPage);
                        updateListControls();
                    });
                }

                const toggleViewBtn = () => {
                    viewLess.classList.toggle('d-none');
                    viewAll.classList.toggle('d-none');
                };

                if (viewAll) {
                    viewAll.addEventListener('click', () => {
                        bookingList.show(1, totalItem);
                        pageQuantity = 1;
                        pageCount = 1;
                        numberOfcurrentItems = totalItem;
                        updateListControls();
                        toggleViewBtn();
                    });
                }
                if (viewLess) {
                    viewLess.addEventListener('click', () => {
                        bookingList.show(1, itemsPerPage);
                        pageQuantity = Math.ceil(totalItem / itemsPerPage);
                        pageCount = 1;
                        numberOfcurrentItems = bookingList.visibleItems.length;
                        updateListControls();
                        toggleViewBtn();
                    });
                }
                if (options.pagination) {
                    table.querySelector('.pagination').addEventListener('click', e => {
                        if (e.target.classList[0] === 'page') {
                            pageCount = Number(e.target.innerText);
                            updateListControls();
                        }
                    });
                }
                if (options.filter) {
                    const { key } = options.filter;
                    listFilter.addEventListener('change', e => {
                        bookingList.filter(item => {
                            if (e.target.value === '') {
                                return true;
                            }
                            return item.values()[key].toLowerCase().includes(e.target.value.toLowerCase());
                        });
                    });
                }
            }
        },



        // ****************************      calendar       ********************************

        

        fullCalendarInit: function fullCalendarInit() {
            var calendars = document.querySelectorAll('[data-calendar]');
            calendars.forEach(function (item) {
                var options = utils.getData(item, 'calendar');
                renderCalendar(item, options);
            });
        },

        setEvents: function setEvents(bookingevents) {
            events = [...bookingevents]
        },

        appCalendarInit: function () {
            var merge = window._.merge;
            var renderCalendar = function renderCalendar(el, option) {
                var _document$querySelect;

                var options = merge({
                    initialView: 'dayGridMonth',
                    editable: true,
                    direction: document.querySelector('html').getAttribute('dir'),
                    headerToolbar: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'dayGridMonth,timeGridWeek,timeGridDay'
                    },
                    buttonText: {
                        month: 'Month',
                        week: 'Week',
                        day: 'Day'
                    }
                }, option);
                var calendar = new window.FullCalendar.Calendar(el, options);
                calendar.render();
                (_document$querySelect = document.querySelector('.navbar-vertical-toggle')) === null || _document$querySelect === void 0 ? void 0 : _document$querySelect.addEventListener('navbar.vertical.toggle', function () {
                    return calendar.updateSize();
                });
                return calendar;
            };
            var fullCalendarInit = function fullCalendarInit() {
                var calendars = document.querySelectorAll('[data-calendar]');
                calendars.forEach(function (item) {
                    var options = utils.getData(item, 'calendar');
                    renderCalendar(item, options);
                });
            };

            var fullCalendar = {
                renderCalendar: renderCalendar,
                fullCalendarInit: fullCalendarInit
            };
            events = getEvents();

            var Selectors = {
                ACTIVE: '.active',
                ADD_EVENT_FORM: '#addEventForm',
                ADD_EVENT_MODAL: '#addEventModal',
                CALENDAR: '#appCalendar',
                CALENDAR_TITLE: '.calendar-title',
                DATA_CALENDAR_VIEW: '[data-fc-view]',
                DATA_EVENT: '[data-event]',
                DATA_VIEW_TITLE: '[data-view-title]',
                EVENT_DETAILS_MODAL: '#eventDetailsModal',
                EVENT_DETAILS_MODAL_CONTENT: '#eventDetailsModal .modal-content',
                EVENT_START_DATE: '#addEventModal [name="startDate"]',
                INPUT_TITLE: '[name="title"]'
            };
            var Events = {
                CLICK: 'click',
                SHOWN_BS_MODAL: 'shown.bs.modal',
                SUBMIT: 'submit'
            };
            var DataKeys = {
                EVENT: 'event',
                FC_VIEW: 'fc-view'
            };
            var ClassNames = {
                ACTIVE: 'active'
            };
            var eventList = events.reduce(function (acc, val) {
                return val.schedules ? acc.concat(val.schedules.concat(val)) : acc.concat(val);
            }, []);

            var updateTitle = function updateTitle(title) {
                document.querySelector(Selectors.CALENDAR_TITLE).textContent = title;
            };

            var appCalendar = document.querySelector(Selectors.CALENDAR);
            var addEventForm = document.querySelector(Selectors.ADD_EVENT_FORM);
            var addEventModal = document.querySelector(Selectors.ADD_EVENT_MODAL);
            var eventDetailsModal = document.querySelector(Selectors.EVENT_DETAILS_MODAL);

            if (appCalendar) {
                var calendar = renderCalendar(appCalendar, {
                    headerToolbar: false,
                    dayMaxEvents: 2,
                    height: 800,
                    stickyHeaderDates: false,
                    views: {
                        week: {
                            eventLimit: 3
                        }
                    },

                    eventTimeFormat: {
                        hour: 'numeric',
                        minute: '2-digit',
                        omitZeroMinute: true,
                        meridiem: true
                    },
                    events: eventList,
                    eventClick: function eventClick(info) {

                        if (info.event.extendedProps.links) {

                            var template = getTemplate(info.event);
                            document.querySelector(Selectors.EVENT_DETAILS_MODAL_CONTENT).innerHTML = template;
                            var modal = new window.bootstrap.Modal(eventDetailsModal);
                            modal.show();

                            var links = info.event.extendedProps.links;
                            links.forEach(function (link) {

                                var _link = document.querySelector("#eventDetailsModal .modal-content #".concat(link.elementId));
                                _link.href = link.href;
                                _link.addEventListener('click', function () {
                                    info.jsEvent.preventDefault()
                                    window.navigationManager.navigateTo(_link.href);
                                    modal.hide();
                                    return false
                                });
                            });
                        }
                        if (info.event.url) {
                            window.navigationManager.navigateTo(info.event.url);
                            info.jsEvent.preventDefault();
                        }
                   
                    },
                    dateClick: function dateClick(info) {
                        var modal = new window.bootstrap.Modal(addEventModal);
                        modal.show();
                        /*eslint-disable-next-line*/

                        var flatpickr = document.querySelector(Selectors.EVENT_START_DATE)._flatpickr;

                        if (flatpickr) {
                            flatpickr.setDate([info.dateStr]);

                        } else {
                            console.error("flatpickr is not initialized");
                       
                        }
                    }
                });
                updateTitle(calendar.currentData.viewTitle);
                document.querySelectorAll(Selectors.DATA_EVENT).forEach(function (button) {
                    button.addEventListener(Events.CLICK, function (e) {
                        var el = e.currentTarget;
                        var type = utils.getData(el, DataKeys.EVENT);

                        switch (type) {
                            case 'prev':
                                calendar.prev();
                                updateTitle(calendar.currentData.viewTitle);
                                break;

                            case 'next':
                                calendar.next();
                                updateTitle(calendar.currentData.viewTitle);
                                break;

                            case 'today':
                                calendar.today();
                                updateTitle(calendar.currentData.viewTitle);
                                break;

                            default:
                                calendar.today();
                                updateTitle(calendar.currentData.viewTitle);
                                break;
                        }
                    });
                });
                document.querySelectorAll(Selectors.DATA_CALENDAR_VIEW).forEach(function (link) {
                    link.addEventListener(Events.CLICK, function (e) {
                        e.preventDefault();
                        var el = e.currentTarget;
                        var text = el.textContent;
                        el.parentElement.querySelector(Selectors.ACTIVE).classList.remove(ClassNames.ACTIVE);
                        el.classList.add(ClassNames.ACTIVE);
                        document.querySelector(Selectors.DATA_VIEW_TITLE).textContent = text;
                        calendar.changeView(utils.getData(el, DataKeys.FC_VIEW));
                        updateTitle(calendar.currentData.viewTitle);
                    });
                });
                addEventForm && addEventForm.addEventListener(Events.SUBMIT, function (e) {
                    e.preventDefault();
                    var _e$target = e.target,
                        title = _e$target.title,
                        startDate = _e$target.startDate,
                        endDate = _e$target.endDate,
                        label = _e$target.label,
                        description = _e$target.description,
                        allDay = _e$target.allDay;
                    calendar.addEvent({
                        title: title.value,
                        start: startDate.value,
                        end: endDate.value ? endDate.value : null,
                        allDay: allDay.checked,
                        className: allDay.checked && label.value ? "bg-soft-".concat(label.value) : '',
                        description: description.value
                    });
                    e.target.reset();
                    window.bootstrap.Modal.getInstance(addEventModal).hide();
                });
            }

            addEventModal && addEventModal.addEventListener(Events.SHOWN_BS_MODAL, function (_ref13) {
                var currentTarget = _ref13.currentTarget;
                currentTarget.querySelector(Selectors.INPUT_TITLE).focus();
            });

        },

        // ****************************      management calendar       ********************************
        setManagementEvents: function setManagementEvents(bookingevents) {

            managementEvents = [...bookingevents]
        },
        managementCalendarInit: function () {




            var Selectors = {
                ADD_EVENT_FORM: '#addEventForm',
                ADD_EVENT_MODAL: '#addEventModal',
                CALENDAR: '#managementAppCalendar',
                EVENT_DETAILS_MODAL: '#eventDetailsModal',
                EVENT_DETAILS_MODAL_CONTENT: '#eventDetailsModal .modal-content',
               

                DATA_EVENT: '[data-event]',
                DATA_VIEW_TITLE: '[data-view-title]',
                EVENT_START_DATE: '#addEventModal [name="startDate"]',
                EVENT_MANAGEMENT_INFO: '[data-calendar-events]'
            };
            var Events = {
                CLICK: 'click',
                SUBMIT: 'submit'
            };
            var managementEventList = [];
            var DataKeys = {
                EVENT: 'event'
            };
            var managementCalendar = document.querySelector(Selectors.CALENDAR);

            if (managementCalendar) {
                var calendarData = utils.getData(managementCalendar, 'calendar-option');
                var managementCalendarEvents = document.getElementById(calendarData === null || calendarData === void 0 ? void 0 : calendarData.events);
                var addEventForm = document.querySelector(Selectors.ADD_EVENT_FORM);
                var addEventModal = document.querySelector(Selectors.ADD_EVENT_MODAL);
                var eventDetailsModal = document.querySelector(Selectors.EVENT_DETAILS_MODAL);

                var updateTitle = function updateTitle(title) {
                    var selectTitle = document.getElementById(calendarData === null || calendarData === void 0 ? void 0 : calendarData.title);

                    if (selectTitle) {
                        selectTitle.textContent = title;
                    }
                };

                var updateDay = function updateDay(day) {
                    var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
                    var selectDay = document.getElementById(calendarData === null || calendarData === void 0 ? void 0 : calendarData.day);

                    if (selectDay) {
                        selectDay.textContent = days[day];
                    }
                };

                if (managementEvents) {
                    managementEvents.forEach(function (e) {
                        managementEventList.push({
                            start: e.start,
                            end: e.end,
                            display: 'background',
                            classNames: "border border-2 border-".concat(e.classNames, " bg-100")
                        });
                    });
                }

                if (managementCalendarEvents) {
                    managementEvents.forEach(function (e) {
                        managementCalendarEvents.innerHTML += "\n          <li class= 'border-top pt-3 mb-3 pb-1 cursor-pointer' data-calendar-events>\n            <div class= 'border-start border-3 border-".concat(e.classNames, " ps-3 mt-1'>\n              <h6 class=\"mb-1 fw-semi-bold text-700\">").concat(e.title, "</h6>\n              <p class= 'fs--2 text-600 mb-0'>").concat(e.startTime || '', " ").concat(e.endTime ? '-' : '', " ").concat(e.endTime || '', "</p>\n            </div>\n          </li> ");
                    });
                }

                var eventManagementInfo = document.querySelectorAll(Selectors.EVENT_MANAGEMENT_INFO);

                if (eventManagementInfo) {
                    eventManagementInfo.forEach(function (li, index) {
                        li.addEventListener(Events.CLICK, function () {
                            var event = managementEvents[index];
                            var template = getTemplate(event);
                            document.querySelector(Selectors.EVENT_DETAILS_MODAL_CONTENT).innerHTML = template;
                            var modal = new window.bootstrap.Modal(eventDetailsModal);
                            modal.show();
                        });
                    });
                }

                if (managementCalendar) {
                    var calendar = renderCalendar(managementCalendar, {
                        headerToolbar: false,
                        dayMaxEvents: 2,
                        height: 360,
                        stickyHeaderDates: false,
                        dateClick: function dateClick(info) {
                            var modal = new window.bootstrap.Modal(addEventModal);
                            modal.show();
                            /*eslint-disable-next-line*/

                            var flatpickr = document.querySelector(Selectors.EVENT_START_DATE)._flatpickr;

                            flatpickr.setDate([info.dateStr]);
                        },
                        events: managementEventList
                    });
                    updateTitle(calendar.currentData.viewTitle);
                    updateDay(calendar.currentData.currentDate.getDay());
                    document.querySelectorAll(Selectors.DATA_EVENT).forEach(function (button) {
                        button.addEventListener(Events.CLICK, function (e) {
                            var el = e.currentTarget;
                            var type = utils.getData(el, DataKeys.EVENT);

                            switch (type) {
                                case 'prev':
                                    calendar.prev();
                                    updateTitle(calendar.currentData.viewTitle);
                                    break;

                                case 'next':
                                    calendar.next();
                                    updateTitle(calendar.currentData.viewTitle);
                                    break;

                                case 'today':
                                    calendar.today();
                                    updateTitle(calendar.currentData.viewTitle);
                                    break;

                                default:
                                    calendar.today();
                                    updateTitle(calendar.currentData.viewTitle);
                                    break;
                            }
                        });
                    });

                    if (addEventForm) {
                        addEventForm.addEventListener(Events.SUBMIT, function (e) {
                            e.preventDefault();
                            e.target.reset();
                            window.bootstrap.Modal.getInstance(addEventModal).hide();
                        });
                    }
                }
            }

            var thisDay = window.dayjs && window.dayjs().format('DD');
            var plus2Day = window.dayjs && window.dayjs().add(2, 'day').format('DD');
            var thisMonthNumber = window.dayjs && window.dayjs().format('MM');
            var thisMonthName = window.dayjs && window.dayjs().format('MMM');
            var upcomingMonthNumber = window.dayjs && window.dayjs().add(1, 'month').format('MM');
            var upcomingMonthName = window.dayjs && window.dayjs().format('MMM');
            var thisYear = window.dayjs && window.dayjs().format('YYYY');

            var managementEvents = getManagementEvents();
            //var managementEvents = [{
            //    title: 'Monthly team meeting for Falcon React Project',
            //    start: "".concat(thisYear, "-").concat(thisMonthNumber, "-07"),
            //    end: "".concat(thisYear, "-").concat(thisMonthNumber, "-09"),
            //    startTime: "07 ".concat(thisMonthName, ", ").concat(thisYear),
            //    endTime: "10 ".concat(thisMonthName, ", ").concat(thisYear),
            //    classNames: 'primary',
            //    extendedProps: {
            //        description: 'Boston Harbor Now in partnership with the Friends of Christopher Columbus Park, the Wharf District Council.',
            //        location: 'Boston Harborwalk, Christopher Columbus Park, <br /> Boston, MA 02109, United States',
            //        organizer: 'Boston Harbor Now'
            //    }
            //}, {
            //    title: 'Newmarket Nights',
            //    start: "".concat(thisYear, "-").concat(thisMonthNumber, "-16"),
            //    end: "".concat(thisYear, "-").concat(thisMonthNumber, "-18"),
            //    startTime: "16 ".concat(thisMonthName, ", ").concat(thisYear),
            //    classNames: 'success',
            //    extendedProps: {
            //        description: 'Boston Harbor Now in partnership with the Friends of Christopher Columbus Park, the Wharf District Council.',
            //        location: 'Boston Harborwalk, Christopher Columbus Park, <br /> Boston, MA 02109, United States',
            //        organizer: 'Boston Harbor Now'
            //    }
            //}, {
            //    title: 'Folk Festival',
            //    start: "".concat(thisYear, "-").concat(thisMonthNumber, "-25"),
            //    end: "".concat(thisYear, "-").concat(thisMonthNumber, "-28"),
            //    startTime: "07 ".concat(thisMonthName, ", ").concat(thisYear),
            //    endTime: "10 ".concat(thisMonthName, ", ").concat(thisYear),
            //    classNames: 'warning',
            //    extendedProps: {
            //        description: 'Boston Harbor Now in partnership with the Friends of Christopher Columbus Park, the Wharf District Council.',
            //        location: 'Boston Harborwalk, Christopher Columbus Park, <br /> Boston, MA 02109, United States',
            //        organizer: 'Boston Harbor Now'
            //    }
            //}, {
            //    title: 'Film Festival',
            //    start: "".concat(thisYear, "-").concat(upcomingMonthNumber, "-").concat(thisDay),
            //    end: "".concat(thisYear, "-").concat(upcomingMonthNumber, "-").concat(plus2Day),
            //    startTime: "07 ".concat(upcomingMonthName, ", ").concat(thisYear),
            //    endTime: "10 ".concat(upcomingMonthName, ", ").concat(thisYear),
            //    classNames: 'danger',
            //    extendedProps: {
            //        description: 'Boston Harbor Now in partnership with the Friends of Christopher Columbus Park, the Wharf District Council.',
            //        location: 'Boston Harborwalk, Christopher Columbus Park, <br /> Boston, MA 02109, United States',
            //        organizer: 'Boston Harbor Now'
            //    }
            //}, {
            //    title: 'Meeting',
            //    start: "".concat(thisYear, "-").concat(upcomingMonthNumber, "-28"),
            //    startTime: "07 ".concat(upcomingMonthName, ", ").concat(thisYear),
            //    classNames: 'warning',
            //    extendedProps: {
            //        description: 'Boston Harbor Now in partnership with the Friends of Christopher Columbus Park, the Wharf District Council.',
            //        location: 'Boston Harborwalk, Christopher Columbus Park, <br /> Boston, MA 02109, United States',
            //        organizer: 'Boston Harbor Now'
            //    }
            //}];



        },

        // ****************************      bulk select       ********************************
        bulkSelectInit: function bulkSelectInit() {
            var BulkSelect = /*#__PURE__*/function () {
                function BulkSelect(element, option) {
                    _classCallCheck(this, BulkSelect);

                    this.element = new DomNode(element);
                    this.option = _objectSpread({
                        displayNoneClassName: 'd-none'
                    }, option);
                }

                _createClass(BulkSelect, [{
                    key: "init",
                    value: function init() {
                        this.attachNodes();
                        this.clickBulkCheckbox();
                        this.clickRowCheckbox();
                    }
                }, {
                    key: "attachNodes",
                    value: function attachNodes() {
                        var _this$element$data = this.element.data('bulk-select'),
                            body = _this$element$data.body,
                            actions = _this$element$data.actions,
                            replacedElement = _this$element$data.replacedElement;

                        this.actions = new DomNode(document.getElementById(actions));
                        this.replacedElement = new DomNode(document.getElementById(replacedElement));
                        this.bulkSelectRows = document.getElementById(body).querySelectorAll('[data-bulk-select-row]');
                    }
                }, {
                    key: "clickBulkCheckbox",
                    value: function clickBulkCheckbox() {
                        var _this = this;

                        // Handle click event in bulk checkbox
                        this.element.on('click', function () {
                            if (_this.element.attr('indeterminate') === 'indeterminate') {
                                _this.actions.addClass(_this.option.displayNoneClassName);

                                _this.replacedElement.removeClass(_this.option.displayNoneClassName);

                                _this.removeBulkCheck();

                                _this.bulkSelectRows.forEach(function (el) {
                                    var rowCheck = new DomNode(el);
                                    rowCheck.setProp('checked', false);
                                    rowCheck.setAttribute('checked', false);
                                });

                                return;
                            }

                            _this.toggleDisplay();

                            _this.bulkSelectRows.forEach(function (el) {
                                var rowCheck = new DomNode(el);
                                rowCheck.setProp('checked', _this.element.attr('checked'));
                                rowCheck.setAttribute('checked', _this.element.attr('checked'));
                            });
                        });
                    }
                }, {
                    key: "clickRowCheckbox",
                    value: function clickRowCheckbox() {
                        var _this2 = this;

                        // Handle click event in checkbox of each row
                        this.bulkSelectRows.forEach(function (el) {
                            var rowCheck = new DomNode(el);
                            rowCheck.on('click', function () {
                                if (_this2.element.attr('indeterminate') !== 'indeterminate') {
                                    _this2.element.setProp('indeterminate', true);

                                    _this2.element.setAttribute('indeterminate', 'indeterminate');

                                    _this2.element.setProp('checked', true);

                                    _this2.element.setAttribute('checked', true);

                                    _this2.actions.removeClass(_this2.option.displayNoneClassName);

                                    _this2.replacedElement.addClass(_this2.option.displayNoneClassName);
                                }

                                if (_toConsumableArray(_this2.bulkSelectRows).every(function (element) {
                                    return element.checked;
                                })) {
                                    _this2.element.setProp('indeterminate', false);

                                    _this2.element.setAttribute('indeterminate', false);
                                }

                                if (_toConsumableArray(_this2.bulkSelectRows).every(function (element) {
                                    return !element.checked;
                                })) {
                                    _this2.removeBulkCheck();

                                    _this2.toggleDisplay();
                                }
                            });
                        });
                    }
                }, {
                    key: "removeBulkCheck",
                    value: function removeBulkCheck() {
                        this.element.setProp('indeterminate', false);
                        this.element.removeAttribute('indeterminate');
                        this.element.setProp('checked', false);
                        this.element.setAttribute('checked', false);
                    }
                }, {
                    key: "toggleDisplay",
                    value: function toggleDisplay() {
                        this.actions.toggleClass(this.option.displayNoneClassName);
                        this.replacedElement.toggleClass(this.option.displayNoneClassName);
                    }
                }]);

                return BulkSelect;
            }();




            var bulkSelects = document.querySelectorAll('[data-bulk-select');

            if (bulkSelects.length) {
                bulkSelects.forEach(function (el) {
                    var bulkSelect = new BulkSelect(el);
                    bulkSelect.init();
                });
            }
        },

        // ****************************      data table       ********************************

        dataTableDestroy: function dataTableDestroy() {
            if (window.jQuery) {
                var $ = window.jQuery;
                var dataTables = $('.data-table');
                dataTables.length && dataTables.each(function (index, value) {
                    var $this = $(value);
                    $this.DataTable().destroy();
                });
            }


        },
        listInit: function listInit() {
            if (window.List) {
                var lists = document.querySelectorAll('[data-list]');

                if (lists.length) {
                    lists.forEach(function (el) {
                        var options = utils.getData(el, 'list');

                        if (options.pagination) {
                            options = _objectSpread(_objectSpread({}, options), {}, {
                                pagination: _objectSpread({
                                    item: '<li><button class=\'page\' type=\'button\'></button></li>'
                                }, options.pagination)
                            });
                        }

                        var paginationButtonNext = el.querySelector('[data-list-pagination="next"]');
                        var paginationButtonPrev = el.querySelector('[data-list-pagination="prev"]');
                        var viewAll = el.querySelector('[data-list-view="*"]');
                        var viewLess = el.querySelector('[data-list-view="less"]');
                        var listInfo = el.querySelector('[data-list-info]');
                        var listFilter = document.querySelector('[data-list-filter]');
                        var list = new window.List(el, options); //-------fallback-----------

                        list.on('updated', function (item) {
                            var fallback = el.querySelector('.fallback') || document.getElementById(options.fallback);

                            if (fallback) {
                                if (item.matchingItems.length === 0) {
                                    fallback.classList.remove('d-none');
                                } else {
                                    fallback.classList.add('d-none');
                                }
                            }
                        }); // ---------------------------------------

                        var totalItem = list.items.length;
                        var itemsPerPage = list.page;
                        var btnDropdownClose = list.listContainer.querySelector('.btn-close');
                        var pageQuantity = Math.ceil(totalItem / itemsPerPage);
                        var numberOfcurrentItems = list.visibleItems.length;
                        var pageCount = 1;
                        btnDropdownClose && btnDropdownClose.addEventListener('search.close', function () {
                            list.fuzzySearch('');
                        });

                        var updateListControls = function updateListControls() {
                            listInfo && (listInfo.innerHTML = "".concat(list.i, " to ").concat(numberOfcurrentItems, " of ").concat(totalItem));
                            paginationButtonPrev && togglePaginationButtonDisable(paginationButtonPrev, pageCount === 1);
                            paginationButtonNext && togglePaginationButtonDisable(paginationButtonNext, pageCount === pageQuantity);

                            if (pageCount > 1 && pageCount < pageQuantity) {
                                togglePaginationButtonDisable(paginationButtonNext, false);
                                togglePaginationButtonDisable(paginationButtonPrev, false);
                            }
                        }; // List info


                        updateListControls();

                        if (paginationButtonNext) {
                            paginationButtonNext.addEventListener('click', function (e) {
                                e.preventDefault();
                                pageCount += 1;
                                var nextInitialIndex = list.i + itemsPerPage;
                                nextInitialIndex <= list.size() && list.show(nextInitialIndex, itemsPerPage);
                                numberOfcurrentItems += list.visibleItems.length;
                                updateListControls();
                            });
                        }

                        if (paginationButtonPrev) {
                            paginationButtonPrev.addEventListener('click', function (e) {
                                e.preventDefault();
                                pageCount -= 1;
                                numberOfcurrentItems -= list.visibleItems.length;
                                var prevItem = list.i - itemsPerPage;
                                prevItem > 0 && list.show(prevItem, itemsPerPage);
                                updateListControls();
                            });
                        }

                        var toggleViewBtn = function toggleViewBtn() {
                            viewLess.classList.toggle('d-none');
                            viewAll.classList.toggle('d-none');
                        };

                        if (viewAll) {
                            viewAll.addEventListener('click', function () {
                                list.show(1, totalItem);
                                pageQuantity = 1;
                                pageCount = 1;
                                numberOfcurrentItems = totalItem;
                                updateListControls();
                                toggleViewBtn();
                            });
                        }

                        if (viewLess) {
                            viewLess.addEventListener('click', function () {
                                list.show(1, itemsPerPage);
                                pageQuantity = Math.ceil(totalItem / itemsPerPage);
                                pageCount = 1;
                                numberOfcurrentItems = list.visibleItems.length;
                                updateListControls();
                                toggleViewBtn();
                            });
                        } // numbering pagination


                        if (options.pagination) {
                            el.querySelector('.pagination').addEventListener('click', function (e) {
                                if (e.target.classList[0] === 'page') {
                                    pageCount = Number(e.target.innerText);
                                    updateListControls();
                                }
                            });
                        }

                        if (options.filter) {
                            var key = options.filter.key;
                            listFilter.addEventListener('change', function (e) {
                                list.filter(function (item) {
                                    if (e.target.value === '') {
                                        return true;
                                    }

                                    return item.values()[key].toLowerCase().includes(e.target.value.toLowerCase());
                                });
                            });
                        }
                    });
                }
            }
        },
        dataTablesInit: function dataTablesInit() {
            if (window.jQuery) {
                var $ = window.jQuery;
                var dataTables = $('.data-table');

                var customDataTable = function customDataTable(elem) {
                    elem.find('.pagination').addClass('pagination-sm');
                };

                dataTables.length && dataTables.each(function (index, value) {
                    var $this = $(value);
                    var options = $.extend({
                        dom: "<'row mx-0'<'col-md-6'l><'col-md-6'f>>" + "<'table-responsive scrollbar'tr>" + "<'row g-0 align-items-center justify-content-center justify-content-sm-between'<'col-auto mb-2 mb-sm-0 px-3'i><'col-auto px-3'p>>"
                    }, $this.data('options'));
                    $this.DataTable(options);
                    var $wrpper = $this.closest('.dataTables_wrapper');
                    customDataTable($wrpper);
                    $this.on('draw.dt', function () {
                        return customDataTable($wrpper);
                    });
                });

                
            }
        }
        // ****************************      wizrd       ********************************
        ,
        wizardInit: function wizardInit() {
            var wizards = document.querySelectorAll('.theme-wizard');
            var tabPillEl = document.querySelectorAll('#pill-tab2 [data-bs-toggle="pill"]');
            var tabProgressBar = document.querySelector('.theme-wizard .progress');
            wizards.forEach(function (wizard) {
                var tabToggleButtonEl = wizard.querySelectorAll('[data-wizard-step]');
                var inputEmail = wizard.querySelector('[data-wizard-validate-email]');
                var emailPattern = '/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/'//.getAttribute('pattern');
                var inputPassword = wizard.querySelector('[data-wizard-validate-password]');
                var inputConfirmPassword = wizard.querySelector('[data-wizard-validate-confirm-password]');
                var form = wizard.querySelector('[novalidate]');
                var nextButton = wizard.querySelector('.next button');
                var prevButton = wizard.querySelector('.previous button');
                var cardFooter = wizard.querySelector('.theme-wizard .card-footer');
                var count = 0;

                var validatePattern = function validatePattern(pattern, value) {
                    var regexPattern = new RegExp(pattern);
                    return regexPattern.test(String(value).toLowerCase());
                };

                prevButton.classList.add('d-none'); // on button click tab change

                nextButton.addEventListener('click', function () {
                //    if ((!(inputEmail.value && validatePattern(emailPattern, inputEmail.value)) || !inputPassword.value || !inputConfirmPassword.value) && form.className.includes('needs-validation')) {

                    if (false) { 
                    form.classList.add('was-validated');
                    } else {
                        count += 1;
                        var tab = new window.bootstrap.Tab(tabToggleButtonEl[count]);
                        tab.show();
                    }
                });
                prevButton.addEventListener('click', function () {
                    count -= 1;
                    var tab = new window.bootstrap.Tab(tabToggleButtonEl[count]);
                    tab.show();
                });

                if (tabToggleButtonEl.length) {
                    tabToggleButtonEl.forEach(function (item, index) {
                        /* eslint-disable */
                        item.addEventListener('shown.bs.tab', function (e) {
                            //if ((!(null && validatePattern(emailPattern, inputEmail.value)) || !inputPassword.value || !inputConfirmPassword.value) && form.className.includes('needs-validation')) {
                            if (false) { 
                            e.preventDefault();
                                form.classList.add('was-validated');
                                return null;
                                /* eslint-enable */
                            }

                            count = index;

                            // can't go back tab

                            //if (count === tabToggleButtonEl.length - 1) {
                            //    tabToggleButtonEl.forEach(function (tab) {
                            //        tab.setAttribute('data-bs-toggle', 'modal');
                            //        tab.setAttribute('data-bs-target', '#error-modal');
                            //    });
                            //}
                            //add done class

                            for (var i = 0; i < count; i += 1) {
                                tabToggleButtonEl[i].classList.add('done');
                            }
                            //remove done class


                            for (var j = count; j < tabToggleButtonEl.length; j += 1) {
                                tabToggleButtonEl[j].classList.remove('done');
                            }
                            // card footer remove at last step

                            if (count > tabToggleButtonEl.length - 2) {
                                item.classList.add('done');
                                cardFooter.classList.add('d-none');
                            } else {
                                cardFooter.classList.remove('d-none');
                            } // prev-button removing


                            if (count > 0) {
                                prevButton.classList.remove('d-none');
                            } else {
                                prevButton.classList.add('d-none');
                            }
                        });
                    });
                }
            });
            // control wizard progressbar

            if (tabPillEl.length) {
                var dividedProgressbar = 100 / tabPillEl.length;
                tabProgressBar.querySelector('.progress-bar').style.width = "".concat(dividedProgressbar, "%");
                tabPillEl.forEach(function (item, index) {
                    item.addEventListener('shown.bs.tab', function () {
                        tabProgressBar.querySelector('.progress-bar').style.width = "".concat(dividedProgressbar * (index + 1), "%");
                    });
                });
            }
        }
    }



})();


// ****************************      calendar       ********************************

var events = [];
var navigationManagerObject;
var getEvents = function getEvents() {
    return events;
};
var getManagementEvents = function getManagementEvents() {
    return managementEvents;
    };

var getStackIcon = function getStackIcon(icon, transform) {
    return "\n  <span class=\"fa-stack ms-n1 me-3\">\n    <i class=\"fas fa-circle fa-stack-2x text-200\"></i>\n    <i class=\"".concat(icon, " fa-stack-1x text-primary\" data-fa-transform=").concat(transform, "></i>\n  </span>\n");
};

var getTemplate = function getTemplate(event) {
    return "\n<div class=\"modal-header bg-light ps-card pe-5 border-bottom-0\">\n  <div>\n    <h5 class=\"modal-title mb-0\">".concat(event.title, "</h5>\n    ").concat(event.extendedProps.organizer ? "<p class=\"mb-0 fs--1 mt-1\">\n        by <a href=\"#!\">".concat(event.extendedProps.organizer, "</a>\n      </p>") : '', "\n  </div>\n  <button type=\"button\" class=\"btn-close position-absolute end-0 top-0 mt-3 me-3\" data-bs-dismiss=\"modal\" aria-label=\"Close\"></button>\n</div>\n<div class=\"modal-body px-card pb-card pt-1 fs--1\">\n  ").concat(event.extendedProps.description ? "\n      <div class=\"d-flex mt-3\">\n        ".concat(getStackIcon('fas fa-align-left'), "\n        <div class=\"flex-1\">\n          <h6>Description</h6>\n          <p class=\"mb-0\">\n            \n          ").concat(event.extendedProps.description.split(' ').slice(0, 30).join(' '), "\n          </p>\n        </div>\n      </div>\n    ") : '', " \n  <div class=\"d-flex mt-3\">\n    ").concat(getStackIcon('fas fa-calendar-check'), "\n    <div class=\"flex-1\">\n        <h6>Date and Time</h6>\n        <p class=\"mb-1\">\n          ").concat(window.dayjs && window.dayjs(event.start).format('dddd, MMMM D, YYYY, h:mm A'), " \n          ").concat(event.end ? "\u2013 <br/>".concat(window.dayjs && window.dayjs(event.end).subtract(1, 'day').format('dddd, MMMM D, YYYY, h:mm A')) : '', "\n        </p>\n    </div>\n  </div>\n  ").concat(event.extendedProps.location ? "\n        <div class=\"d-flex mt-3\">\n          ".concat(getStackIcon('fas fa-map-marker-alt'), "\n          <div class=\"flex-1\">\n              <h6>Location</h6>\n              <p class=\"mb-0\">").concat(event.extendedProps.location, "</p>\n          </div>\n        </div>\n      ") : '', "\n  ").concat(event.schedules ? "\n        <div class=\"d-flex mt-3\">\n        ".concat(getStackIcon('fas fa-clock'), "\n        <div class=\"flex-1\">\n            <h6>Schedule</h6>\n            \n            <ul class=\"list-unstyled timeline mb-0\">\n              ").concat(event.schedules.map(function (schedule) {
        return "<li>".concat(schedule.title, "</li>");
    }).join(''), "\n            </ul>\n        </div>\n      ") : '', "\n  </div>\n</div>\n<div class=\"modal-footer d-flex justify-content-end bg-light px-card border-top-0\">\n  <a id='edit-event'  href='#' class=\"btn btn-falcon-default btn-sm\">\n    <span class=\"fas fa-pencil-alt fs--2 mr-2\"></span> Edit\n  </a>\n <a id='get-event' href='#' class=\"btn btn-falcon-primary btn-sm\">\n    See more details\n    <span class=\"fas fa-angle-right fs--2 ml-1\"></span>\n  </a>\n</div>\n");
};