import sys
from PyQt5.QtWidgets import QApplication, QWidget, QVBoxLayout, QLineEdit, QPushButton, QGridLayout

class Calculator(QWidget):
    def __init__(self):
        super().__init__()
        self.init_ui()

    def init_ui(self):
        self.setWindowTitle('Simple Calculator')

        layout = QVBoxLayout()

        self.display = QLineEdit()
        self.display.setFixedHeight(50)
        self.display.setReadOnly(True)

        layout.addWidget(self.display)

        grid = QGridLayout()

        buttons = [
            '7', '8', '9', '/',
            '4', '5', '6', '*',
            '1', '2', '3', '-',
            'C', '0', '=', '+'
        ]

        positions = [(i, j) for i in range(4) for j in range(4)]

        for position, button in zip(positions, buttons):
            if button == 'C':
                btn = QPushButton(button)
                btn.clicked.connect(self.clear)
            elif button == '=':
                btn = QPushButton(button)
                btn.clicked.connect(self.calculate)
            else:
                btn = QPushButton(button)
                btn.clicked.connect(lambda _, text=button: self.on_button_click(text))

            grid.addWidget(btn, *position)

        layout.addLayout(grid)
        self.setLayout(layout)

    def on_button_click(self, text):
        self.display.setText(self.display.text() + text)

    def calculate(self):
        try:
            result = str(eval(self.display.text()))
            self.display.setText(result)
        except:
            self.display.setText("Error")

    def clear(self):
        self.display.clear()

if __name__ == '__main__':
    app = QApplication(sys.argv)
    calculator = Calculator()
    calculator.show()
    sys.exit(app.exec_())
