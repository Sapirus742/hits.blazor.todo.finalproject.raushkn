window.renderOperationsChart = (income, expense, transfers) => {
    const canvas = document.getElementById('operationsChart');
    if (!canvas) return false;
    
    if (window.operationsChartInstance) {
        window.operationsChartInstance.destroy();
    }
    
    const ctx = canvas.getContext('2d');
    window.operationsChartInstance = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Приход', 'Расход', 'Внутренние переводы'],
            datasets: [{
                data: [income, expense, transfers],
                backgroundColor: ['#28a745', '#dc3545', '#ffc107']
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            devicePixelRatio: 2,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        font: {
                            size: 16,
                            family: "'Segoe UI', Arial, sans-serif"
                        },
                        padding: 10
                    }
                }
            }
        }
    });
    return true;
};

window.renderDepartmentsChart = (labels, balances) => {
    const canvas = document.getElementById('departmentsChart');
    if (!canvas) return false;
    
    if (window.departmentsChartInstance) {
        window.departmentsChartInstance.destroy();
    }
    
    const ctx = canvas.getContext('2d');
    window.departmentsChartInstance = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Баланс (руб.)',
                data: balances,
                backgroundColor: '#17a2b8'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            devicePixelRatio: 2,
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        font: {
                            size: 14,
                            family: "'Segoe UI', Arial, sans-serif"
                        }
                    }
                },
                x: {
                    ticks: {
                        font: {
                            size: 16,
                            family: "'Segoe UI', Arial, sans-serif"
                        }
                    }
                }
            },
            plugins: {
                legend: {
                    labels: {
                        font: {
                            size: 16,
                            family: "'Segoe UI', Arial, sans-serif"
                        }
                    }
                }
            }
        }
    });
    return true;
};
