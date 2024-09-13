(function () {
    window.navigationManager = {

        navigationManagerInit: function navigationManagerInit(navigationmanageObject) {

            navigationManagerObject = navigationmanageObject; 
        },

        navigateTo: function navigateTo(url) {
            navigationManagerObject.invokeMethodAsync('NavigateTo', url);
        },


    }

    window.bookingTableManager = {


        advanceAjaxTableInit: function advanceAjaxTableInit(bookings, navigationManager) {

            const orders = [
                {
                    id: 1,
                    dropdownId: 'order-dropdown-1',
                    orderId: '#181',
                    mailLink: 'mailto:ricky@example.com',
                    name: 'Ricky Antony',
                    email: 'ricky@example.com',
                    date: '20/04/2019',
                    address: 'Ricky Antony, 2392 Main Avenue, Penasauka, New Jersey 02149',
                    shippingType: 'Via Flat Rate',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$99'
                },
                {
                    id: 2,
                    dropdownId: 'order-dropdown-2',
                    orderId: '#182',
                    mailLink: 'mailto:kin@example.com',
                    name: 'Kin Rossow',
                    email: 'kin@example.com',
                    date: '20/04/2019',
                    address: 'Kin Rossow, 1 Hollywood Blvd,Beverly Hills, California 90210',
                    shippingType: 'Via Free Shipping',
                    status: 'Processing',
                    badge: { type: 'primary', icon: 'fas fa-redo' },
                    amount: '$120'
                },
                {
                    id: 3,
                    dropdownId: 'order-dropdown-3',
                    orderId: '#183',
                    mailLink: 'mailto:merry@example.com',
                    name: 'Merry Diana',
                    email: 'merry@example.com',
                    date: '30/04/2019',
                    address: 'Merry Diana, 1 Infinite Loop, Cupertino, California 90210',
                    shippingType: 'Via Link Road',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$70'
                },
                {
                    id: 4,
                    dropdownId: 'order-dropdown-4',
                    orderId: '#184',
                    mailLink: 'mailto:bucky@example.com',
                    name: 'Bucky Robert',
                    email: 'bucky@example.com',
                    date: '30/04/2019',
                    address: 'Bucky Robert, 1 Infinite Loop, Cupertino, California 90210',
                    shippingType: 'Via Free Shipping',
                    status: 'Pending',
                    badge: { type: 'warning', icon: 'fas fa-stream' },
                    amount: '$92'
                },
                {
                    id: 5,
                    dropdownId: 'order-dropdown-5',
                    orderId: '#185',
                    mailLink: 'mailto:rocky@example.com',
                    name: 'Rocky Zampa',
                    email: 'rocky@example.com',
                    date: '30/04/2019',
                    address: 'Rocky Zampa, 1 Infinite Loop, Cupertino, California 90210',
                    shippingType: 'Via Free Road',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$120'
                },
                {
                    id: 6,
                    dropdownId: 'order-dropdown-6',
                    orderId: '#186',
                    mailLink: 'mailto:ricky@example.com',
                    name: 'Ricky John',
                    email: 'ricky@example.com',
                    date: '30/04/2019',
                    address: 'Ricky John, 1 Infinite Loop, Cupertino, California 90210',
                    shippingType: 'Via Free Shipping',
                    status: 'Processing',
                    badge: { type: 'primary', icon: 'fas fa-redo' },
                    amount: '$145'
                },
                {
                    id: 7,
                    dropdownId: 'order-dropdown-7',
                    orderId: '#187',
                    mailLink: 'mailto:cristofer@example.com',
                    name: 'Cristofer Henric',
                    email: 'cristofer@example.com',
                    date: '30/04/2019',
                    address: 'Cristofer Henric, 1 Infinite Loop, Cupertino, California 90210',
                    shippingType: 'Via Flat Rate',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$55'
                },
                {
                    id: 8,
                    dropdownId: 'order-dropdown-8',
                    orderId: '#188',
                    mailLink: 'mailto:lee@example.com',
                    name: 'Brate Lee',
                    email: 'lee@example.com',
                    date: '29/04/2019',
                    address: 'Brate Lee, 1 Infinite Loop, Cupertino, California 90210',
                    shippingType: 'Via Link Road',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$90'
                },
                {
                    id: 9,
                    dropdownId: 'order-dropdown-9',
                    orderId: '#189',
                    mailLink: 'mailto:Stephenson@example.com',
                    name: 'Thomas Stephenson',
                    email: 'Stephenson@example.com',
                    date: '29/04/2019',
                    address: 'Thomas Stephenson, 116 Ballifeary Road, Bamff',
                    shippingType: 'Via Flat Rate',
                    status: 'Processing',
                    badge: { type: 'primary', icon: 'fas fa-redo' },
                    amount: '$52'
                },
                {
                    id: 10,
                    dropdownId: 'order-dropdown-10',
                    orderId: '#190',
                    mailLink: 'mailto:eviewsing@example.com',
                    name: 'Evie Singh',
                    email: 'eviewsing@example.com',
                    date: '29/04/2019',
                    address: 'Evie Singh, 54 Castledore Road, Tunstead',
                    shippingType: 'Via Flat Rate',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$90'
                },
                {
                    id: 11,
                    dropdownId: 'order-dropdown-11',
                    orderId: '#191',
                    mailLink: 'mailto:peter@example.com',
                    name: 'David Peters',
                    email: 'peter@example.com',
                    date: '29/04/2019',
                    address: 'David Peters, Rhyd Y Groes, Rhosgoch, LL66 0AT',
                    shippingType: 'Via Link Road',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$69'
                },
                {
                    id: 12,
                    dropdownId: 'order-dropdown-12',
                    orderId: '#192',
                    mailLink: 'mailto:jennifer@example.com',
                    name: 'Jennifer Johnson',
                    email: 'jennifer@example.com',
                    date: '28/04/2019',
                    address: 'Jennifer Johnson, Rhyd Y Groes, Rhosgoch, LL66 0AT',
                    shippingType: 'Via Flat Rate',
                    status: 'Processing',
                    badge: { type: 'primary', icon: 'fas fa-redo' },
                    amount: '$112'
                },
                {
                    id: 13,
                    dropdownId: 'order-dropdown-13',
                    orderId: '#193',
                    mailLink: 'mailto:okuneva@example.com',
                    name: ' Demarcus Okuneva',
                    email: 'okuneva@example.com',
                    date: '28/04/2019',
                    address: ' Demarcus Okuneva, 90555 Upton Drive Jeffreyview, UT 08771',
                    shippingType: 'Via Flat Rate',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$99'
                },
                {
                    id: 14,
                    dropdownId: 'order-dropdown-14',
                    orderId: '#194',
                    mailLink: 'mailto:simeon@example.com',
                    name: 'Simeon Harber',
                    email: 'simeon@example.com',
                    date: '27/04/2019',
                    address: 'Simeon Harber, 702 Kunde Plain Apt. 634 East Bridgetview, HI 13134-1862',
                    shippingType: 'Via Free Shipping',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$129'
                },
                {
                    id: 15,
                    dropdownId: 'order-dropdown-15',
                    orderId: '#195',
                    mailLink: 'mailto:lavon@example.com',
                    name: 'Lavon Haley',
                    email: 'lavon@example.com',
                    date: '27/04/2019',
                    address: 'Lavon Haley, 30998 Adonis Locks McGlynnside, ID 27241',
                    shippingType: 'Via Free Shipping',
                    status: 'Pending',
                    badge: { type: 'warning', icon: 'fas fa-stream' },
                    amount: '$70'
                },
                {
                    id: 16,
                    dropdownId: 'order-dropdown-16',
                    orderId: '#196',
                    mailLink: 'mailto:ashley@example.com',
                    name: 'Ashley Kirlin',
                    email: 'ashley@example.com',
                    date: '26/04/2019',
                    address: 'Ashley Kirlin, 43304 Prosacco Shore South Dejuanfurt, MO 18623-0505',
                    shippingType: 'Via Link Road',
                    status: 'Processing',
                    badge: { type: 'primary', icon: 'fas fa-redo' },
                    amount: '$39'
                },
                {
                    id: 17,
                    dropdownId: 'order-dropdown-17',
                    orderId: '#197',
                    mailLink: 'mailto:johnnie@example.com',
                    name: 'Johnnie Considine',
                    email: 'johnnie@example.com',
                    date: '26/04/2019',
                    address: 'Johnnie Considine, 6008 Hermann Points Suite 294 Hansenville, TN 14210',
                    shippingType: 'Via Flat Rate',
                    status: 'Pending',
                    badge: { type: 'warning', icon: 'fas fa-stream' },
                    amount: '$70'
                },
                {
                    id: 18,
                    dropdownId: 'order-dropdown-18',
                    orderId: '#198',
                    mailLink: 'mailto:trace@example.com',
                    name: 'Trace Farrell',
                    email: 'trace@example.com',
                    date: '26/04/2019',
                    address: 'Trace Farrell, 431 Steuber Mews Apt. 252 Germanland, AK 25882',
                    shippingType: 'Via Free Shipping',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$70'
                },
                {
                    id: 19,
                    dropdownId: 'order-dropdown-19',
                    orderId: '#199',
                    mailLink: 'mailto:nienow@example.com',
                    name: 'Estell Nienow',
                    email: 'nienow@example.com',
                    date: '26/04/2019',
                    address: 'Estell Nienow, 4167 Laverna Manor Marysemouth, NV 74590',
                    shippingType: 'Via Free Shipping',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$59'
                },
                {
                    id: 20,
                    dropdownId: 'order-dropdown-20',
                    orderId: '#200',
                    mailLink: 'mailto:howe@example.com',
                    name: 'Daisha Howe',
                    email: 'howe@example.com',
                    date: '25/04/2019',
                    address: 'Daisha Howe, 829 Lavonne Valley Apt. 074 Stehrfort, RI 77914-0379',
                    shippingType: 'Via Free Shipping',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$39'
                },
                {
                    id: 21,
                    dropdownId: 'order-dropdown-21',
                    orderId: '#201',
                    mailLink: 'mailto:haley@example.com',
                    name: 'Miles Haley',
                    email: 'haley@example.com',
                    date: '24/04/2019',
                    address: 'Miles Haley, 53150 Thad Squares Apt. 263 Archibaldfort, MO 00837',
                    shippingType: 'Via Flat Rate',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$55'
                },
                {
                    id: 22,
                    dropdownId: 'order-dropdown-22',
                    orderId: '#202',
                    mailLink: 'mailto:watsica@example.com',
                    name: 'Brenda Watsica',
                    email: 'watsica@example.com',
                    date: '24/04/2019',
                    address: "Brenda Watsica, 9198 O'Kon Harbors Morarborough, IA 75409-7383",
                    shippingType: 'Via Free Shipping',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$89'
                },
                {
                    id: 23,
                    dropdownId: 'order-dropdown-23',
                    orderId: '#203',
                    mailLink: 'mailto:ellie@example.com',
                    name: "Ellie O'Reilly",
                    email: 'ellie@example.com',
                    date: '24/04/2019',
                    address: "Ellie O'Reilly, 1478 Kaitlin Haven Apt. 061 Lake Muhammadmouth, SC 35848",
                    shippingType: 'Via Free Shipping',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$47'
                },
                {
                    id: 24,
                    dropdownId: 'order-dropdown-24',
                    orderId: '#204',
                    mailLink: 'mailto:garry@example.com',
                    name: 'Garry Brainstrow',
                    email: 'garry@example.com',
                    date: '23/04/2019',
                    address: 'Garry Brainstrow, 13572 Kurt Mews South Merritt, IA 52491',
                    shippingType: 'Via Free Shipping',
                    status: 'Completed',
                    badge: { type: 'success', icon: 'fas fa-check' },
                    amount: '$139'
                },
                {
                    id: 25,
                    dropdownId: 'order-dropdown-25',
                    orderId: '#205',
                    mailLink: 'mailto:estell@example.com',
                    name: 'Estell Pollich',
                    email: 'estell@example.com',
                    date: '23/04/2019',
                    address: 'Estell Pollich, 13572 Kurt Mews South Merritt, IA 52491',
                    shippingType: 'Via Free Shipping',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$49'
                },
                {
                    id: 26,
                    dropdownId: 'order-dropdown-26',
                    orderId: '#206',
                    mailLink: 'mailto:ara@example.com',
                    name: 'Ara Mueller',
                    email: 'ara@example.com',
                    date: '23/04/2019',
                    address: 'Ara Mueller, 91979 Kohler Place Waelchiborough, CT 41291',
                    shippingType: 'Via Flat Rate',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$19'
                },
                {
                    id: 27,
                    dropdownId: 'order-dropdown-27',
                    orderId: '#207',
                    mailLink: 'mailto:blick@example.com',
                    name: 'Lucienne Blick',
                    email: 'blick@example.com',
                    date: '23/04/2019',
                    address: 'Lucienne Blick, 6757 Giuseppe Meadows Geraldinemouth, MO 48819-4970',
                    shippingType: 'Via Flat Rate',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$59'
                },
                {
                    id: 28,
                    dropdownId: 'order-dropdown-28',
                    orderId: '#208',
                    mailLink: 'mailto:haag@example.com',
                    name: 'Laverne Haag',
                    email: 'haag@example.com',
                    date: '22/04/2019',
                    address: 'Laverne Haag, 2327 Kaylee Mill East Citlalli, AZ 89582-3143',
                    shippingType: 'Via Flat Rate',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$49'
                },
                {
                    id: 29,
                    dropdownId: 'order-dropdown-29',
                    orderId: '#209',
                    mailLink: 'mailto:bednar@example.com',
                    name: 'Brandon Bednar',
                    email: 'bednar@example.com',
                    date: '22/04/2019',
                    address: 'Brandon Bednar, 25156 Isaac Crossing Apt. 810 Lonborough, CO 83774-5999',
                    shippingType: 'Via Flat Rate',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$39'
                },
                {
                    id: 30,
                    dropdownId: 'order-dropdown-30',
                    orderId: '#210',
                    mailLink: 'mailto:dimitri@example.com',
                    name: 'Dimitri Boehm',
                    email: 'dimitri@example.com',
                    date: '23/04/2019',
                    address: 'Dimitri Boehm, 71603 Wolff Plains Apt. 885 Johnstonton, MI 01581',
                    shippingType: 'Via Flat Rate',
                    status: 'On Hold',
                    badge: { type: 'secondary', icon: 'fas fa-ban' },
                    amount: '$111'
                }
            ];

            const togglePaginationButtonDisable = (button, disabled) => {
                const updatedButton = button;
                updatedButton.disabled = disabled;
                updatedButton.classList[disabled ? 'add' : 'remove']('disabled');
            };
            // Selectors
            const table = document.getElementById('bookingListTable');

            if (table) {
                const options = {
                    page: 10,
                    pagination: {
                        item: "<li><button class='page' type='button'></button></li>"
                    },
                    item: values => {
                        const { orderId, id, name, email, date, address, shippingType, status, badge, amount } =
                            values;
                        return `
          <tr class="btn-reveal-trigger">
            <td class="order py-2 align-middle white-space-nowrap">
              <a href="https://prium.github.io/falcon/v3.16.0/app/e-commerce/orders/order-details.html">
                <strong>${orderId}</strong>
              </a>
              by
              <strong>${name}</strong>
              <br />
              <a href="mailto:${email}">${email}</a>
            </td>
            <td class="py-2 align-middle">
              ${date}
            </td>
            <td class="py-2 align-middle white-space-nowrap">
              ${address}
              <p class="mb-0 text-500">${shippingType}</p>
            </td>
            <td class="py-2 align-middle text-center fs-9 white-space-nowrap">
              <span class="badge rounded-pill d-block badge-soft-${badge.type}">
                ${status}
                <span class="ms-1 ${badge.icon}" data-fa-transform="shrink-2"></span>
              </span>
            </td>
            <td class="py-2 align-middle text-end fs-9 fw-medium">
              ${amount}
            </td>
            <td class="py-2 align-middle white-space-nowrap text-end">
              <div class="dropstart font-sans-serif position-static d-inline-block">
                <button class="btn btn-link text-600 btn-sm dropdown-toggle btn-reveal" type='button' id="order-dropdown-${id}" data-bs-toggle="dropdown" data-boundary="window" aria-haspopup="true" aria-expanded="false" data-bs-reference="parent">
                  <span class="fas fa-ellipsis-h fs-10"></span>
                </button>
                <div class="dropdown-menu dropdown-menu-end border py-2" aria-labelledby="order-dropdown-${id}">
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

                const orderList = new window.List(table, options, orders);

                // Fallback
                orderList.on('updated', item => {
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

                const totalItem = orderList.items.length;
                const itemsPerPage = orderList.page;
                const btnDropdownClose = orderList.listContainer.querySelector('.btn-close');
                let pageQuantity = Math.ceil(totalItem / itemsPerPage);
                let numberOfcurrentItems = orderList.visibleItems.length;
                let pageCount = 1;

                btnDropdownClose &&
                    btnDropdownClose.addEventListener('search.close', () => orderList.fuzzySearch(''));

                const updateListControls = () => {
                    listInfo &&
                        (listInfo.innerHTML = `${orderList.i} to ${numberOfcurrentItems} of ${totalItem}`);
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

                        const nextInitialIndex = orderList.i + itemsPerPage;
                        nextInitialIndex <= orderList.size() && orderList.show(nextInitialIndex, itemsPerPage);
                        numberOfcurrentItems += orderList.visibleItems.length;
                        updateListControls();
                    });
                }

                if (paginationButtonPrev) {
                    paginationButtonPrev.addEventListener('click', e => {
                        e.preventDefault();
                        pageCount -= 1;

                        numberOfcurrentItems -= orderList.visibleItems.length;
                        const prevItem = orderList.i - itemsPerPage;
                        prevItem > 0 && orderList.show(prevItem, itemsPerPage);
                        updateListControls();
                    });
                }

                const toggleViewBtn = () => {
                    viewLess.classList.toggle('d-none');
                    viewAll.classList.toggle('d-none');
                };

                if (viewAll) {
                    viewAll.addEventListener('click', () => {
                        orderList.show(1, totalItem);
                        pageQuantity = 1;
                        pageCount = 1;
                        numberOfcurrentItems = totalItem;
                        updateListControls();
                        toggleViewBtn();
                    });
                }
                if (viewLess) {
                    viewLess.addEventListener('click', () => {
                        orderList.show(1, itemsPerPage);
                        pageQuantity = Math.ceil(totalItem / itemsPerPage);
                        pageCount = 1;
                        numberOfcurrentItems = orderList.visibleItems.length;
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
                        orderList.filter(item => {
                            if (e.target.value === '') {
                                return true;
                            }
                            return item.values()[key].toLowerCase().includes(e.target.value.toLowerCase());
                        });
                    });
                }
            }
        },
    }

    window.oneModuleToRuleThemAll = {


        // ****************************      exports       ********************************




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
                var emailPattern = inputEmail.getAttribute('pattern');
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
                    if ((!(inputEmail.value && validatePattern(emailPattern, inputEmail.value)) || !inputPassword.value || !inputConfirmPassword.value) && form.className.includes('needs-validation')) {
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
                            if ((!(inputEmail.value && validatePattern(emailPattern, inputEmail.value)) || !inputPassword.value || !inputConfirmPassword.value) && form.className.includes('needs-validation')) {
                                e.preventDefault();
                                form.classList.add('was-validated');
                                return null;
                                /* eslint-enable */
                            }

                            count = index; // can't go back tab

                            if (count === tabToggleButtonEl.length - 1) {
                                tabToggleButtonEl.forEach(function (tab) {
                                    tab.setAttribute('data-bs-toggle', 'modal');
                                    tab.setAttribute('data-bs-target', '#error-modal');
                                });
                            } //add done class


                            for (var i = 0; i < count; i += 1) {
                                tabToggleButtonEl[i].classList.add('done');
                            } //remove done class


                            for (var j = count; j < tabToggleButtonEl.length; j += 1) {
                                tabToggleButtonEl[j].classList.remove('done');
                            } // card footer remove at last step


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
            }); // control wizard progressbar

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